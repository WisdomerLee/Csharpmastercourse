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

    public class Person
    {
        public string Name { get; }

        

        public int YearOfBirth { get; }
        public Person(string name, int yearofBirth)
        {
            Name = name;
            YearOfBirth = yearofBirth;
        }

        public Person(string name) => Name = name;
    }


    internal class AttributeType
    {
    }
}
