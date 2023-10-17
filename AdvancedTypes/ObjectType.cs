using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes
{
    //System.Object 타입에서 호출할 수 있는 메소드들
    //ReferenceEquals 메서드는 어떤 역할을 수행하는가?

    //ToString() : 문자열로 만들기
    //GetType() : Reflection에서 다룬 내용.. 해당 오브젝트가 어느 타입인지 돌려 줌.. 함수, 생성자 등등의 정보등이 포함된 값을 돌려준다!
    //Equals() : 서로 같은 것인지 확인
    
    //object.ReferenceEquals(object, object) : 값이 같은지를 확인하는 것이 아닌, 두 객체가 같은 오브젝트를 가리키고 있는지를 판별함!, 즉 값이 같더라도 다른 오브젝트를 참조로 쓰게 되면 다르다는 값을 출력
    //위의 함수는 value type에는 적용할 수 없음 > value type은 위의 메서드에 들어가는 순간 boxing이 일어나 같은 값을 갖는 다른 객체로 생성되어 다르다고 인지하게 됨...
    //또한 RefereceEquals 메서드는 static이어서 우리가 그 내용을 덮어쓸 수 없음
    //value type에서도 같다는 것을 확인할 수 있으려면??
    
    //Equals() : 서로 같은지 확인하는 메서드
    //value, reference 타입의 기본 행동
    //

    //Equals() :
    //Equality operator를 씀 "=="
    //Equals() : virtual로 선언되어 있어 함수의 비교 내용을 덮어쓸 수 있음!!!

    //struct는 value type이므로 Equals로 처리될 때 그 값만 비교하여 값이 같으면 참이 반환됨
    //Equals() 함수는 value type일 경우는 그 값이 같은지 확인, reference type인 경우 reference가 같은 지 확인
    //둘 다 override로 덮어쓸 수 있음

    //class에서 Equals 메서드 덮어쓰기!

    class PersonEOverride
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public PersonEOverride(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            //아래의 표현은 obj의 타입이 PersonEOverride이면서 Id가 서로 같을 경우에 같은 것으로 인식함
            return obj is PersonEOverride other && Id == other.Id;
        }
        //일반적으로 Equals()함수를 덮어씌울 때 GetHashCode의 함수도 덧씌우는데 이는 Equals에서 같음을 판별할 때 쓰는 함수이기도 함..
        //

    }

    //일반적으로 struct는 필드의 모든 값이 같아야 같음을 돌려주지만, 연산의 빠르기를 위해 structure의 고유 ID가 있는 데이터 형태라면
    //해당 ID가 같은지만 놓고도 같다는 것을 판별할 수 있게 Equals()함수를 덮어씌울수도 있음
    //대개의 경우는 성능상의 이유로 struct의 Equals 함수를 덮어씌움
    //기본 Equals()함수는 reflection을 이용하여 비교 > reflection를 활용하면 느림
    //Equals함수를 덮어씌워 성능을 보다 빠르게...
    //Equals()함수를 자주 쓸 경우에는 덮어씌워야 함

    //생각보다 Equals()함수는 자주 쓰임 : 다른 함수 내부에서 호출되는 등...
    //Contains()함수에서도, IndexOf()함수에서도 Remove()함수에서도 쓰임
    //Dictionary 데이터타입에서는 key를 이용하여 Equals()함수를 씀 : 해당 내용은 Collections쪽에서 다룰 예정
    //struct의 경우에도 Equals함수를 덮어씌울 것!! : Relection 대신 ==오퍼레이터를 이용하여 성능 저하를 막음
    //struct의 이름을 우클릭하여 Refactoring쪽을 클릭하여보면...?
    //Equals()함수를 덮어씌울 지 혹은 Equals()와 GetHashCode()함수를 덮어씌울지 선택할 수 있음
    //대부분의 경우는 Equals()와 GetHashCode()둘 다 덮어씌우는 것이 일반적
    //그래서 Equals()함수를 덮어씌울 것인지를 선택하면
    //어느 속성을 비교할 것인지를 물어봄!
    //또한 Implement IEquatable<해당 struct>쪽에도 적용할지를 선택할 수 있음!!!
    //Generate operators라는 옵션도 선택할 수 있음 > 이 부분은 나중에 추가로 진행될 예정...
    //그래서 저 속성들을 선택하면 자동으로 Equals()함수를 생성해줌!

    //IEquatable<T> interface이 무엇인지, 언제 이것을 집어넣어서 쓰는지
    //IComparable<T> interface와의 차이는?
    //만약 두 함수에서 같은 이름을 가진 타입이 있으면?? 그리고 그것을 두 함수에서 모두 쓸 경우 어떤 일이 벌어지는가?
    //기본적인 struct의 같음을 판단하는 Equals()함수의 경우
    //object로 전달되므로 boxing이 일어나고 > object에서 struct의 값을 도로 꺼내오는 과정에서 unboxing이 일어남
    //그리고 그 값을 비교하는 과정에서 Reflection을 이용하여 type이 같은지를 확인하고 값을 비교함...
    //object로 받아들이는 형태로 덮어씌우면 boxing, unboxing과정은 그대로 남아있음
    //Equals()함수를 아예 struct 타입으로 받아들이도록 덮어씌우면??
    // boxing, unboxing 과정 자체도 사라짐
    //리턴값이 같고 이름이 같은 함수가 입력 타입이 다른 함수가 둘이 있으면??
    //입력되는 데이터 값이 특수한 형태의 함수가 호출됨

    struct PointEOverride : IEquatable<PointEOverride> //이 IEquatable<T>인터페이스는 Equals(T t)함수를 갖고 있음!!!
    {
        public int X { get; init; }
        public int Y { get; init; }
        public PointEOverride(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString() => $"X: {X}, Y: {Y}";

        public override bool Equals(object? obj)
        {
            return obj is PointEOverride other && Equals(other);
        }
        //하지만 보다 특수한 형태로 object 대신 아래와 같이 쓴다면??
        public bool Equals(PointEOverride other)
        {
            return X == other.X && Y == other.Y;
        }
        //그냥 Equals()함수를 호출하게 되면 아래의 함수를 호출하게 됨: 데이터 타입이 보다 특수한 형태를 먼저 호출하게 된다고 함
    }


    //Contains함수에서 Equals()함수가 내부적으로 쓰이는데 이 때 DataType은 어느 것이 될 수 있으므로 object 타입으로 받아들이게 됨
    //boxing, unboxing이 일어나는 것은 당연한 수순
    //하지만 들어가는 데이터 타입 T가 IEquatable<T>인터페이스를 구현하고 있으면 (해당 interface는 Equals(T t)메소드를 갖고 있음)
    //Contains 함수에서 호출하는 Equals()함수는 IEquatable<T>로 내장된 Equals()함수를 호출하게 됨!!! > 성능이 더 좋아짐 : 비교속도가 빨라짐!!
    

    //IEquatable<T> : 두 오브젝트가 같은지를 판별, bool값을 반환
    //IComparable<T> : 순서를 정렬하기 전에 확인, int 값을 반환(-1, 0, 1)

    //record struct라는 데이터 타입이 있는데 이 struct는 같음 등의 내용이 들어간 내용들을 단 한 줄로 표현할 수 있음!!

    //== operator
    //value, reference 
    // == : reference type : Equals()함수처럼 동작
    //== : value type의 경우엔 동작하지 않음..

    //value type : Equals()를 덮어씌우는 이유 : 성능상의 이유, 물론 덮어씌우지 않아도 됨
    //== 덮어씌우는 이유? ==를 쓸 수 있도록 하기 위해...
    //
    //reference type의 경우
    //value를 기준으로 equality를 판별할 경우 Equals()함수를 덮어씌우는 것, == 연산자를 덮어씌우는 것 모두 가능
    //reference 기준으로 equality를 판별할 경우 Equals()함수를 덮어씌우는 것, == 연산자를 덮어씌우는 것은...? X
    //만약 Equals()함수를 둘 다 지원하도록 덮어씌우기는 할 수 있음, == 는 지원하지 않음!



    internal class ObjectType
    {

    }
}
