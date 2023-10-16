using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes
{
    //Struct 타입
    //클래스와 어떻게 다른가?
    //그리고 struct는 최대한 작게 유지해야 하는 까닭
    //그리고 타입 제한을 두어 오직 value 타입만 쓸 수 있도록 정의할 수 있는지 확인
    //class : reference type
    //struct : value type
    //value type은 value의 값들을 모두 독립적으로 저장해 둘 수 있음
    //value type은 그 값을 변경하려면 variable에 직접 접근하여 변경하는 방법 외엔 없음!

    //struct는 오직 stack에만 존재하는데 stack은 매우 작은 메모리를 갖고 있으므로 struct는 되도록 작아야 함


    //가장 근본적인 struct와 class의 차이
    //struct : value type
    //class : reference type
    //null 값은 reference type에만 허용됨 : null reference의 줄임말
    
    //모든 struct : sealed되어 상속이 허용되지 않음 : sealed 키워드와 함께 쓸 수는 없음
    //struct는 바로 위의 이유로 virtual, override를 쓸 수 없음
    //struct 내부에 interface를 상속받아(모든 interface는 reference타입) interface의 메소드로 파라미터를 전달할 수 있음...
    //그런데 이렇게 처리하면 reference type으로 전환되므로 boxing이 일어남!

    //low-level difference
    //struct는 파라미터 없는 생성자가 반드시 포함됨!
    //struct는 파괴자나 Dispose를 쓸 필요가 없음, (쓸 수 없음)

    //또한 struct는 자기 자신의 타입을 가리키는 부분을 쓸 수 없음 : stack은 매우 작으므로 structure의 크기가 커질 수 있는 이와 같은 상황을 애초에 막음

    //struct를 선택하는 경우 : value semantic을 원할 때
    //C#에서 같음을 처리할 때
    //struct는 그 값들이 모두 같으면 같다고 처리
    //referenct는 그 값이 같더라도 같은 오브젝트를 가리키지 않으면 서로 다르다고 인식

    //struct를 수정할 수 없는 형태로 만들어 쓰면 더 좋은 이유??

    //struct외에도 class를 immutable로 만들어두는 건 종종 좋은 선택이 되기도 함
    //struct를 immutable로 만드는 것은 아주 중요함
    //그리고 C#의 builtin struct는 모두 immutable

    //value type : 무언가를 더하게 되면 다른 오브젝트
    //reference type : 필드 값이 변경되면? 그래도 같은 오브젝트

    //value type의 값을 수정하면 그 오브젝트가 아닌 수정된 값을 가진 채로 새로 생성되는 오브젝트가 하나 추가 생성됨
    //이 방식을 non-destructive mutation이라고 부름

    //"with" expression을 통해 non-destructive mutation을 구현해보자
    
    //Readonly struct
    //struct를 immutable로 직접 만들려면??
    //struct의 모든 필드를 readonly로 지정하고
    //모든 프로퍼티를 get 혹은 set대신 init으로 처리
    
    //하지만 위의 방식은 사람이 처리하다 일 부분 속성에 키워드 적용을 잊을 수도 있고..
    //struct에 새 필드를 적용하면서 immutable 처리를 잊을 수도 있음!



    //property가 init으로 설정되어 처음에 설정된 값을 제외한 값의 수정이 불가능한 상태의 struct가 되었음

    struct Point
    {
        public int X { get; init;}
        public int Y { get; init;}
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString() => $"X: {X}, Y: {Y}";
    }
    //아래와 같이 readonly를 키워드로 붙여 선언하면?? > 읽기 전용이 됨 (수정 불가)
    //그러면 새 필드를 추가하거나 set으로 바꾸게 되면 컴파일 단계에서 에러가 남!
    readonly struct PointReadOnly
    {
        public int X { get; init; }
        public int Y { get; init; }
        public PointReadOnly(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString() => $"X: {X}, Y: {Y}";
    }


    internal class StructType
    {
        void Main()
        {
            var point = new Point(1, 3);
            //var anotherPoint = point;
            //anotherPoint.Y = 100;
            //아래와 같이 처리하면?? 새 오브젝트가 생성되면서 변경된 값이 들어감
            //하나만 혹은 여럿의 프로퍼티를 수정한 상태로 만들 수 있음
            
            var pointMoved = point with { X = point.X + 1 };
            //with를 쓸 수 있으려면 프로퍼티에 get외에도 최소한 init이나 set 부분이 있어야 함
            //with를 쓸 수 있는 곳 : struct, record, record struct, anonymous object들에 쓸 수 있음, class는 해당없음

            //아래와 같이 anonymous type의 오브젝트를 생성하고
            var pet = new { Name = "Hannibal", Type = "Fish" };
            //with expression으로 새 오브젝트를 만들 수 있음
            var asCrab = pet with { Type = "Crab" };

            SomeMethod(5);
            SomeMethod<Point>(new Point(1, 3));
        }
        //아래와 같이 정의하면 value 타입으로 지정된 값만 파라미터로 넣을 수 있음
        //클래스 : reference type이므로 클래스는 파라미터로 넘길 수 없음!
        void SomeMethod<T>(T param) where T : struct
        {

        }
        //아래와 같이 정의 하면 parameter는 무조건 reference 타입만 들어갈 수 있음, 리스트, 배열 등등 + 클래스
        void SomeM<T>(T param) where T : class
        {

        }

    }
}
