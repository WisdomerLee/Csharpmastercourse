using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class GenericMadeindelegate
    {

        //Func, Action을 알아보자!!
        //Func, Action이 무엇인지
        //Func : 함수를 파라미터로 전달할 때도 쓰임! 예를 들면 비교하는 연산이 중간에 다를 경우...등?
        //lambda expressions : 람다 표현식 : 함수가 다른 곳에서 더이상 쓰이지 않고 단 한 번만 쓰일 경우!
        //파라미터, 반환 타입으로 간단히 표현할 수 있음 파라미터 => 반환 타입의 형태로 표시됨

        //delegate와 Func, Action의 차이??
        //C#의 타입 : class, struct, enum, delegate
        //delegate : 함수
        //delegate의 경우 multi형태로 같은 delegate로 선언된 함수를 더하면 > 두 함수를 같이 실행함

        delegate void Print(string input);

        void Operate()
        {
            //print : delegate로 선언된 함수 : 함수의 입력 파라미터, 출력되는 데이터 타입이 같으면 해당 delegate함수로 선언하여 쓸 수 있음
            //함수를 각자 선언할 수도 있고
            Print print1 = text => Console.WriteLine(text.ToUpper());
            Print print2 = text => Console.WriteLine(text.ToLower());
            //각자 선언된 함수 자체를 더하여 쓸 수도 있음
            Print multicast = print1 + print2;
            Print print3 = text => Console.WriteLine(text.Substring(0, 3));
            multicast += print3;
        }

        //Func를 쓰게 되면 delegate를 미리 선언하지 않고도 바로 함수를 쓸 수 있음
        Func<string, string, int> sumLengths = (text1, text2) => text1.Length + text2.Length;
        //delegate : C#에서 Func, Action이 도입되기 전에 쓰이던 것
        //99%의 경우는 delegate를 미리 선언하여 쓸 이유가 거의 없음...
        //Action, Func를 쓸 것
    }
}
