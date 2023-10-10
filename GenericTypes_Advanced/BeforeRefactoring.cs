using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class BeforeRefactoring
    {
        void Operate()
        {
            //숫자 리스트가 하나 주어지고,
            //
            var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
            //쓸 수 있는 해당 필터들을 나열하고
            Console.WriteLine(@"Select filter:
Even
Odd
Positive
");

            var userInput = Console.ReadLine();
            List<int> result = new NumbersFilter().FilterBy(userInput, numbers);
            Print(result);
            
        }
        void Print(IEnumerable<int> numbers)
        {
            Console.WriteLine(string.Join(",", numbers));
        }

    }
    public class NumbersFilter
    {
        public List<int> FilterBy(string filterType, List<int> numbers)
        {
            switch (filterType)
            {
                case "Even":
                    return SelectEven(numbers);
                    
                case "Odd":
                    return SelectOdd(numbers);
                    
                case "Positive":
                    return SelectPositive(numbers);
                default:
                    throw new NotSupportedException($"{filterType} is not a valid filter");

            }
        }

        List<int> SelectEven(List<int> numbers)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }
        List<int> SelectOdd(List<int> numbers)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 1)
                {
                    result.Add(number);
                }
            }
            return result;
        }
        List<int> SelectPositive(List<int> numbers)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }
        //같은 코드 중복이 심화됨 : Select~함수 들 내부는 로직은 거의 일치하고 숫자를 판별하는 부분만 다름을 알 수 있음
    }
}
