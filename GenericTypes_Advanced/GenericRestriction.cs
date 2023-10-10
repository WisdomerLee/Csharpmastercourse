using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class GenericRestriction
    {

        void GenericFunctionExample()
        {

            var people = new List<Person>
{
    new Person{Name="John", YearOfBirth= 1980},
    new Person{Name="Anna", YearOfBirth=1815},
    new Person{Name="Bill", YearOfBirth=2150}
};
            var employees = new List<Employee>
{
    new Employee{Name="John", YearOfBirth=1980},
    new Employee{Name="Anna", YearOfBirth=1815},
    new Employee{Name="Bill", YearOfBirth=2150}
};

            var validPeople = GetOnlyValid(people);
            var validEmployees = GetOnlyValid(employees);

            people.Sort();

            foreach (var employee in validEmployees)
            {
                //동작에는 문제가 없지만
                //캐스팅을 매번 한다면...> 성능 상의 문제가 발생!
                employee.GoToWork();
            }
            string str = "";
            Random random = new Random();
            random.Next();

        }

        IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new() //타입 제한이 들어감 where T : new() : 생성자에 파라미터가 없는 타입들만 들어올 수 있음을 알려줌!
        {
            var length = new Random().Next(maxLength + 1);
            var result = new List<T>(length); //리스트 생성시 리스트 갯수를 미리 지정해 두면 배열의 크기를 늘리는 성능에 영향을 주는 일이 없게 됨!
            for (int i = 0; i < length; ++i)
            {
                result.Add(new T()); //생성자가 파라미터가 반드시 필요한 경우들도 있음! : T는 어떤 타입이 될지 알 수 없으므로 파라미터를 요구하는 생성자의 타입에는 쓸 수 없는 상황이 됨...
                                     //그러면 Generic 중에서도 특정 상황의 애들에 한한 일반적인 함수로 만들어두게 되면(타입 제한 Type Restrict)
            }
            return result;
        }



        IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> persons) where TPerson : Person
        {
            var result = new List<TPerson>();
            foreach (var person in persons)
            {
                if (person.YearOfBirth > 1900 && person.YearOfBirth < DateTime.Now.Year)
                {
                    result.Add(person);
                }
            }
            return result;
        }



        //정렬할 때
        //IComparable interface 활용하기!
        //someObject.CompareTo(otherObject)라는 함수가 있는데 이 함수는 someObject가 otherObject보다 크면 1을 작으면 -1을 돌려줌, 같으면? 0을 반환
        //기본적으로 list등은 Sort라는 정렬 함수를 씀 그런데... 이 정렬의 기준은...? : 사용자가 임의로 만든 클래스 같은 경우엔 사용자가 생각지도 않은 기준으로 순서대로 나열하게 됨...
        //그럴 때 순차대로 나열할 기준을 바탕으로 IComparable interface를 해당 클래스의 내부에 정의하여 두면?? > 사용자가 정의한 기준대로 나열하게 됨

        //크기를 비교하는 일반화 함수의 경우.. : 비교가 가능한 interface를 상속받은 경우에 한하여!
        void PrintInOrder<T>(T first, T second) where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
            {
                Console.WriteLine($"{second} {first}");
            }
            else
            {
                Console.WriteLine($"{first} {second}");
            }
        }



        

    }

    public class Employee : Person
    {
        public void GoToWork() => Console.WriteLine("일하러 가는 중");
    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }

        public int CompareTo(Person other)
        {

            if (YearOfBirth < other.YearOfBirth)
            {
                return 1;
            }
            else if (YearOfBirth > other.YearOfBirth)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
