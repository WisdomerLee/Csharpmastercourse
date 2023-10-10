using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class ExtendedMethodwithGenericRestriction
    {
        void Operate()
        {

            var ints = new List<int> { 1, 2, 3 };
            //확장 메서드로 지정한 함수를 쓸 수 있음 !
            ints.AddToFront(10);

            var decimals = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };
            var int2 = decimals.ConvertTo<decimal, int>();
        }
    }

    //확장 메서드 지정!!! : 확장 메서드는 반드시 static class에서 지정, 확장 메서드는 static으로 선언됨 또한 확장 메서드로 지정될 경우 input parameter로 들어가는 부분에 this가 포함됨
    //확장 메서드는 원본 내용에 접근할 수 없으나 추가 기능 확장이 필요할 경우 쓰임
    static class ListExtensions
    {
        public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> input)
        {
            var result = new List<TTarget>();

            foreach (var item in input)
            {
                TTarget itemAfterCasting = (TTarget)Convert.ChangeType(item, typeof(TTarget));
                result.Add(itemAfterCasting);
            }
            return result;
        }


        public static void AddToFront<T>(this List<T> list, T item)
        {
            list.Insert(0, item);
        }
    }
}
