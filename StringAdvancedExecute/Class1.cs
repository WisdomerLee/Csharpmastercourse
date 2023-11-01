using System.Globalization;
using System.Text;

namespace StringAdvancedExecute
{
    //문자열!!!
    //문자열로 하는 함수의 활용을 최적화를 해보자
    //오브젝트를 문자열로
    //문자열 형식 방법..
    //PDF에서 문자열 추출하기!

    //char ?
    //문자열의 캐릭터를 바꾸는 방법


    public class Class1
    {
        void Main()
        {
            char letter = 'a';
            //char는 ''로 묶이고
            //string은  ""로 묶임

            //char에서 쓸 수 있는 함수
            //IsUpper : 대문자인지 확인
            //IsLetter : 정말 문자인지(숫자 등이 아닌지)
            //IsDigit : 숫자형태인지
            //IsWhiteSpace : 줄 바꿈 혹은 빈 칸인지
            //ToUpper: 대문자로 변경

            //char는 메모리 상에 16bits(2bytes)를 차지함
            //또한 char는 메모리상에 숫자 형태로 저장되기 때문에 ....
            for (char c = 'A'; c<'z'; ++c)
            {
                Console.WriteLine(c);
            }
            //숫자에 어느 문자를 집어넣느냐에 따라 문자 표시가 달라지는데
            //이것을 encoding이라고 부름

            //문자열의 변경 불가능
            //문자열의 데이터 구조
            //C#의 문자열은 모두 변경 불가능함
            //그럼 문자열을 더하는 건 어떻게 가능?? : 새 문자열을 추가로 만들어주는 것..
            //문자열은 reference type
            //그런데 값을 비교하는 것은 value type처럼 진행됨..
            //문자열은 heap에 저장됨..
            //struct는 reference type을 가지면 안 되는 이유
            //문자열은 예외인 이유??

            //struct는 서로 다른 객체라 독립적으로 유지되어야 하나 reference type을 갖게 되면....?
            //하나에 끼친 영향이 다른 struct에 영향을 미침

            //stringbuilder의 필요성
            //문자열은 변경 불가능함
            //그럼 문자열을 엄청나게 변경을 많이 해야 할 경우?? 무수히 많은 오브젝트가 만들어졌다가 사라지게 됨...
            //StringBuilder class를 이용하기
            //(루프 등으로)문자열을 더하거나 빼서 원하는 문자열을 만들 때 좋음
            //버퍼를 만들고 거기에 데이터를 저장해두었다가 마지막에 문자열을 하나만 생성! : 매번 오브젝트를 만들지 않음...
            //루프로 돌리는 값이 많아질 수록 stringbuilder의 위력이 더 세짐...
            var stringBuilder = new StringBuilder();
            for(int i = 0; i<1000000; i++)
            {
                stringBuilder.Append(letter);
            }
            var text2 = stringBuilder.ToString();

            //string interning
            //같은 문자열이 여럿 만들어지면...?
            //char[]로 만드는 것보다 string으로 만드는 것이 최적화가 더 잘됨..
            //같은 문자열을 여럿 만들게 되면 자동으로 같은 오브젝트 reference로 지정...
            //string interning
            //서로 같은 값을 갖는 문자열을 만들면 > 내부적으로 동일한 오브젝트 하나만 생성하고 그 reference를 가리키게 만듦


            //flyweight design pattern
            //flyweight design pattern은 서로 굉장히 비슷한 형태를 갖는 데이터들의 오브젝트들의 메모리 사용 공간을 줄이기 위한 방법!

            //문자열의 string.Format()함수 : 예전 방식이긴 함...
            //추가적으로 숫자형으로 출력할 때...
            var text3 = string.Format("Number 1 is {0}, number 2 is {1, 10:C}", 5, 22);
            //위와 같이 처리하면 number2 is {뒤에 있는 것은} 22를 넣는데 그 칸의 갯수를 강제로 10칸으로 만들어줌...
            //format :C로 넣으면? 돈으로 처리함
            decimal s = 1.45m;
            Console.WriteLine(string.Format("Number is {0:C3}", s)); //화폐인데 3자리로 표현
            Console.WriteLine(string.Format("Number is {0:F1}", s)); //소숫점 첫째자리까지 표현
            Console.WriteLine(string.Format("Number is {0:P}", s)); //백분율로 표시
            //날짜도 포맷 방식을 지정할 수 있음
            DateTime dateTime = new DateTime(2023, 5, 6, 2, 30, 55);
            Console.WriteLine(string.Format("Date is {0:d}", dateTime));
            Console.WriteLine(string.Format("Date is {0:D}", dateTime));
            Console.WriteLine(string.Format("Date is {0:MM/yyyy}", dateTime));
            Console.WriteLine($"Date is {dateTime:d}");

            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            //현재 문화권
            Console.WriteLine(currentCulture);
        }
    }
}