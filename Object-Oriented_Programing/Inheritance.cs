using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Programing
{
    //상속의 개념을 쓰면....? 클래스를 일부 변경하여 써야 할 경우 유용함...
    //base class > inherit class : is - a 관계
    //즉 상속받은 클래스들은 base class 타입으로도 인식될 수 있음!
    //클래스의 polyporphism!!

    //protected : 상속 받은 클래스들은 접근 가능, 그 외 클래스: 접근 불가
    //virtual : 상속받을 수 있는 상태인데 덮어쓸 수 있을 경우 : 상속 받은 상태에서 덧씌우기가 가능한 상태
    //override : 기존 클래스의 내용을 그대로 쓰지 않고 다르게 새로 덮어쓴 내용으로 적용할 때... 원본 함수, 프로퍼티가 virtual 로 선언되어있어야 가능
    //동시 상속은 불가능 : 클래스의 상속은 오직 단일하게만..., 상속에 제한이 없는 특수한 경우 : interface
    //모든 클래스는 Object라는 클래스에서 상속받음, 또한 공통으로 ToString이라는 메소드를 갖고 있음
    //상속받아 덮어쓰기 전의 함수를 불러오고 싶다면 base를 쓸 것

    //implicit conversion :  숫자 int를 float등으로 변경하는 것은 매우 간단.. > 정보가 사라질 일이 없는 변환은 바로 안전하게 이루어짐, 즉 작은 데이터 단위에서 큰 데이터 단위로는 문제 없이 변환이 일어남
    //explicit conversion : 보다 큰 데이터 단위에서 작은 데이터 단위로 바뀐다면??
    //float > int로 conversion이 일어난다면 일부 데이터 손실이 발생할 수 있음 (바꿀 데이터 타입) 을 앞에 두어 강제로 데이터 형태를 바꿀 수 있음!!!
    //explicit conversion의 경우는 형 변환을 했을 때 의도치 않은 변환이 발생할 경우를 생각해두어야 함
    //특히 숫자를 enum으로 변경할 경우 enum에서 지정하지 않은 숫자, 혹은 범위의 숫자가 지정될 경우

    //upcasting, downcasting : 
    //upcasting : 기본 base 클래스를 선언하고 그 하위의 클래스로 만드는 것을 선언할 때 
    //예를 들어 A라는 클래스가 기본, B라는 클래스가 A를 상속받았을 때
    //A aclass = new B();
    //이런 형태로 되는 경우는 upcasting!!!
    //반대의 경우는?? downcating이고 explicit conversion과 같은 형태로 변환함!!

    //is operator : is라는 keyword로 해당 오브젝트가 그 데이터 타입인지를 알려줌
    //Null : 데이터가 기본 타입이 아닌 경우 변수를 선언하고 초기화를 하지 않았을 경우 들어가는 값...
    //NullException은 매우 흔한 오류 중에 하나
    //기본 데이터 타입은 null을 허용하지 않음!!!, int, float 등..

    //as operator : 
    //explicit conversion과 downcasting의 경우 해당되는 타입에 맞지 않을 경우 runtime error를 발생시킴!!
    //explicit conversion, downcasting과 다른 것은 ()로 쓰지 않고 as 클래스이름 으로 변환을 시도하는 것!
    //as의 경우 데이터 타입이 맞지 않으면 null을 반환함!
    //즉 as는 데이터 타입에 null을 허용하는 경우에만 쓰일 수 있음!

    //abstract class : 자체로 객체를 만들 수 없고 오직 상속받은 객체로만 생성이 가능한 클래스!!
    //abstract method : abstract class 내부에 들어있으며 내용은 없고 오직 상속받은 클래스에서 내용을 각각 다르게 부여하여 활용할 함수!
    //abstract class를 상속받은 클래스들은 만약 abstract method가 있으면 그 method를 반드시! override하여 사용하여야 함
    //하지만 상속 받은 것도 abstract class라면?? override를 할 수 없으니 통과!

    //그럼 virtual과 abstract의 공통점은??
    //둘 다 상속받은 클래스에서 내용이 덮어씌워질 수 있음
    //virtual과 abstract의 차이점은??
    //virtual은 함수의 내용이 반드시 있어야 함, 그리고 덮어씌우기는 선택, 일반 클래스에도 쓰일 수 있음
    //abstract는 함수 내용이 없음, 덮어씌우기는 필수! 오직 abstract 클래스에만 있음
    //base class 혹은 abstract class에 공통으로 abstract 함수가 있으면
    //그 내용을 상속받은 어느 클래스라도 어느 경우라도 불러올 수 있음

    //sealed :?? 상속을 금지함!
    //static class : 모두 sealed!!! : 객체를 만들 수 없음!
    //static method는 override될 수 없음!

    //extension methods :만약 기능을 확장하고 싶은 함수의 원형을 우리가 만들지 않고 외부의 라이브러리에서 만들었다면??
    //기능을 확대하고 싶으나 원본을 건드릴 수 없는 상태!
    //만약 문자열을 입력하고 그 문자열에 몇 줄이 있는지 알려주는 함수를 쓰고 싶다면???

    //일반적인 class는 단 하나의 클래스만 상속받을 수 있음!!
    //그럼 상속을 여럿 받아서 처리하고 싶은 것들이 있게 된다면??? 예를 들어 공통 함수가 또 하나 필요한 상태인데 그 내용이 원래 클래스와 별도로 추가로 더 필요하게 된다면??
    //Single Responsibility Principle을 지키면서 그대로 유지할 수 있을까??
    // interface : 다중 상속이 가능!!!
    //그리고 interface에는 원래 함수의 이름만 집어넣고 그 내용을 넣을 수 없었으나 C#언어가 업데이트 되면서 interface의 기본 함수에 기본 내용을 추가할 수 있게 되었다

    //interface, abstract class 차이??
    //interface : 함수들의 집합, 함수 자체의 내용은 제공되지 않음(C# 8.0부터는 함수의 기본 내용도 제공 가능), 어떤 field도 포함하지 않음
    //abstract class : 함수, 변수들이 같이 있음, 함수 자체 내용도 있음, 

    //Json이라는 데이터 타입이 있음
    //2019년 이후부터는 JsonSerializer가 .NET에 포함

    //Dependency Inversion Principle
    //Dependency Injection
    //Dependency Inversion Principle : high-level module: lowlevel modlue에 의존하면 안 됨!
    //둘의 관계는 오직 abstraction으로만 연결되어야 함!
    //Coupling ?? > 한 클래스의 변화가 다른 클래스에도 영향을 줄 경우...

    //Generic Type and Methods
    //IEnumerator interface
    //Generic type : <>라는 형태로 속에 들어갈 형태를 지정할 수 있음
    //<T> : 어느 타입이든 적용 가능
    //Linq라는 라이브러리는 컬렉션에 적용 가능한 간편한 기능을 제공함!

    //하나의 속성으로 아이템 찾기!
    //loop를 돌리고

    //JsonSerialize를 이용하여 파일을 저장하자!

    internal class Inheritance
    {
        string checkword = "";


        void Check()
        {
            var multilineText = @"
첫 번째
두 번째
세 번째
네 번째
";
            int line;
            //CountLines라는 확장 메서드가 string부분에 붙어서 쓰이게 됨!!
            //기본 클래스에 붙지는 않지만...
            multilineText.CountLines();
            //enum이라는 부분에 기능이 확장됨!!
            newSeason.Next();
        }
        //int CountLines(string input) => input.Split(Environment.NewLine).Length;
        Season newSeason = Season.Spring;
        
    }

    //static 으로 기능 확장이 가능! 아래의 클래스는 string 기본 부분에 확장 메서드를 넣는 것!
    public static class StringExtensions
    {
        public static int CountLines(this string input) => input.Split(Environment.NewLine).Length;
    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    //위와 같은 기본 enum부분에 nextSeason을 얻는 기능을 확장하고 싶은 경우...

    public static class SeasonExtensions
    {
        public static Season Next(this Season season)
        {
            int seasonAsInt = (int)season;
            int nextSeason = (seasonAsInt + 1) % 4;
            return (Season)nextSeason;
        }
    }



}
