using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("UtilitiesTest")] //이 조건은 internal로 선언된 것을 해당 프로젝트에서 보일 수 있도록 선언하는 것... : 또한 이 선언은 namespace보다도 더 위에 있어야 함..
//또한 위의 선언은 직접적으로 ""으로 넣어야 함 nameof()를 쓸 수 없음 > 그럼 저 것은 왜 쓰는가? > Unit Test를 할 때 internal로 선언된 클래스들의 함수들을 확인할 때 씀..
namespace Utilities
{
    internal static class EnumerableExtensions
    {
        public static string AsString<T>(this IEnumerable<T> items)
        {
            return string.Join(Environment.NewLine, items);
        }

        public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
        {
            return numbers.Where(IsEven).Sum();
            //int sum = 0;
            //foreach(var number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        sum += number;
            //    }
            //}
            //return sum;

        }
        
        private static bool IsEven(int number) => number % 2 == 0;
    }
    
    public class PublicClass
    {
        
    }
    
    
    file class AccessibleOnlyInThisFile
    {

    }

}