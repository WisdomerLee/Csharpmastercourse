using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImprovePerformance
{
    internal class ParamKeyword
    {
        //params 키워드??
        
    }
    public class Calculator
    {
        //아래와 같이 처리하면 오직 배열, 리스트 등의 컬렉션 형태로된 것들만 처리할 수 있음!!!
        public int Add(IEnumerable<int> numbers) => numbers.Sum();
        //숫자들을 얼마든지 받을 수 있게 하려면..? 1,2,등으로 들어간 값들도 받아서 처리할 수 있음!!!

        public int Add(params int[] numbers) => numbers.Sum();
        //하지만 한계도 있는데
        //함수 하나당 params를 붙일 수 있는 것은 오직 하나의 파라미터 뿐
        //그리고 params는 오직 가장 마지막의 파라미터에만 붙일 수 있음!!
        //그러나 불필요한 함수 오버로딩을 방지할 수 있음!!

    }
}
