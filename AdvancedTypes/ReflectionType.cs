using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes
{
    //Reflection이 무엇이고 언제 유용한지!
    //Type 오브젝트를 ...
    //그리고 upsides, downsides들이 무엇?
    //
    //Reflection : 어플리케이션에서 쓰는 타입들을 코드로 해당 타입들을 불러올 수 있는 방법

    //해당 어플리케이션에서 쓰는 속성의 이름을 불러와서 문자로 바꾸어보기
    class Main
    {
        //record는 추후 상세히 다룰 예정, 일종의 데이터 타입

        record Pet(string name, PetType PetType, float Weight);
        record House(string address, double Area, int Floors);
        enum PetType { Cat, Dog, Fish}
        void MainOperate()
        {
            var converter = new ObjectToTextConverter();
            House house = new House("Maple Road 123", 30.5, 2);
            Console.WriteLine(converter.Convert(house));
        }
    }

    class ObjectToTextConverter
    {
        public string Convert(object obj)
        {
            Type type = obj.GetType();
            //타입에 들어있는 프로퍼티에는 속성 등등이 있음!
            var properties = type.GetProperties().Where(p => p.Name != "EqualityContract");
            //프로퍼티 중에 EqualityContract를 제외한 모든 속성을 다 ...!
            //
            return String.Join(",", properties.Select(property => $"{property.Name} is {property.GetValue(obj)}"));
        }
    }
    //Reflection이 지원되어 할 수 있는 것들
    //~.dll파일들을 실행 중에 불러오기
    //주어진 타입이나 오브젝트를 실행 중에 만들 수 있음
    //기본, 혹은 interface가 포함된 모든 클래스들을 찾을 수 있음
    //Attribute들을 읽어올 수 있음!
    //메소드를 이름으로 실행시킬 수 있음
    //Debugging
    //System.Reflection.Emit 에 있는 함수를 이용하여 실행 중에 새 타입을 만들 수 있음
    //... 등등
    
    //Reflection의 단점 : 유지보수가 어렵고 이해하기 힘듦
    //에러 추적이 쉽지 않음 > 만약 함수를 이름으로 후출하였는데 그 함수의 이름이 바뀌었다면??
    //성능에 커다란 영향을 끼침(느려짐)
    //



    internal class ReflectionType
    {

    }
}
