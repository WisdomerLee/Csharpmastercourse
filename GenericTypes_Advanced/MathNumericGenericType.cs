using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class MathNumericGenericType
    {
    }

    //numeric type! Math!

    public static class Calculator
    {
        //INumber라는 일반 숫자들이라는 개념이 도입되었다! : 어느 숫자 타입이 와도 적용 가능함!
        public static T Square<T>(T input) where T : INumber<T> => input * input;
    }
    //일반적인 T에 대한 제한 사항들은 몇몇 특성이 있는데
    //where T : baseclass
    //where T : IInterface
    //where T: INumber<T>
    //where T: new()

}
