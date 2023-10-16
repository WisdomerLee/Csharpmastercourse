using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes
{
    //Attribute가 무엇이고 어떻게 쓸 수 있는가?
    //사용자 Attribute 정의 방법
    //metadata가 무엇?

    //metadata : 어느 데이터가 어떤 형태의 정보를 제공하는지를 알려주는 데이터
    //즉 특정 데이터가 있으면 해당 데이터의 구조등이 담긴 것이 메타데이터

    //Attribute : metadata를 타입으로 집어넣음??
    //즉 이미 해당 타입에 존재하는 metadat에 타입이나 메서드 정보를 추가로 입력할 수 있음
    //주로 해당 타입의 값이 적합한 값인지를 판별하거나 하는 등의 정보를 추가로 넣을 때 필요

    public class Dog
    {
        [StringLengthValidate(2, 10)] // 사용자 정의 Attribute
        public string Name { get; } //이름은 2~10글자 사이여야 하는 조건을 넣고 싶음
        public Dog(string name) => Name = name;
    }


    public class Person
    {
        [StringLengthValidate(2, 25)] // 사용자 정의 Attribute
        public string Name { get; } //이름은 2~25글자 사이여야 하는 조건을 넣고 싶음
        public int YearOfBirth { get; }
        public Person(string name, int yearofBirth)
        {
            Name = name;
            YearOfBirth = yearofBirth;
        }

        public Person(string name) => Name = name;
    }

    //사용자 정의 Attribute가 적용된 클래스! : Attribute를 상속받아야 함, 그리고 클래스의 이름은 Attribute로 끝나야 함 > Attribute를 제외한 나머지 이름이 자동으로 Attribute로 적용되는 것을 확인할 수 있음
    [AttributeUsage(AttributeTargets.Property)] //: 해당 Attribute는 프로퍼티에 적용되는 대상임을 명시
    class StringLengthValidateAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public StringLengthValidateAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
    //프로퍼티가 조건에 맞는지 판별하는지를 담당하는 클래스
    class Validator
    {
        public bool Validate(object obj)
        {
            var type = obj.GetType();
            //아래의 조건은 : Attribute가 StringLengthValidateAttribute 클래스에서 정의된 것만 얻어오는 것
            var propertiesToValidate = type.GetProperties().Where(propertiy => Attribute.IsDefined(propertiy, typeof(StringLengthValidateAttribute)));

            foreach(var property in propertiesToValidate)
            {
                object? propertyValue = property.GetValue(obj);
                //프로퍼티가 문자열이 아니면??
                if(propertyValue is not string)
                {
                    throw new InvalidOperationException($"Attribute {nameof(StringLengthValidateAttribute)} can only be appplied to strings");
                }
                var value = (string)propertyValue;
                var attribute = (StringLengthValidateAttribute) property.GetCustomAttributes(typeof(StringLengthValidateAttribute), true).First();
                if(value.Length < attribute.Min || value.Length > attribute.Max)
                {
                    Console.WriteLine($"Property{property.Name} is invalid. Value is {value}");
                    return false;
                }
            }
            return true;
        }
    }

    internal class AttributeType
    {
        void Main()
        {
            var validPerson = new Person("John", 1981);
            var invalidDog = new Dog("R");
            var validator = new Validator();

            Console.WriteLine(validator.Validate(validPerson) ? "Person is valid": "Person is invalid");
            Console.WriteLine(validator.Validate(invalidDog) ? "Dog is valid" : "Dog is invalid");

        }
    }
    //Attribute의 적용이 제한되는 파라미터들의 타입
    //모든 것이 Attribute로 적용될 수 있는 것이 아님!
    //기본 데이터 타입들인 string, bool, 숫자형
    //Enums, Type
    //System.Object타입
    //기본 데이터 타입의 1차원 배열
    //위의 경우엔 쓸 수 있으나 List, Dictionary 등은 적용할 수 없음!
    //컴파일 단계에서 모든 값이 들어가야 하는 상황이므로 추가로 데이터가 들어가거나 삭제될 수 있는 형태들은 쓸 수 없음


}
