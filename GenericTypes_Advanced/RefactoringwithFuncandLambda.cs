using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    //Solid pattern 중 Open-Closed Principle을 다룰 예정
    //모듈, 클래스, 함수 등은 확장에는 열려있어야 하고 변경에는 닫혀있어야 함
    //:이미 작성된 코드를 변경하는 것보다, 새 코드를 작성하는 형태로 진행해야 함
    //코드를 변경해야 할 때 : 코드가 더이상 동작하지 않을 때
    //
    internal class RefactoringwithFuncandLambda
    {
        void Operate()
        {
            //숫자 리스트가 하나 주어지고,
            //
            var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
            var filteringStrategySelector = new FilteringStrategySelector();
            //쓸 수 있는 해당 필터들을 나열하고
            Console.WriteLine(@"Select filter");
            Console.WriteLine(string.Join(Environment.NewLine, filteringStrategySelector.FilteringStrategiesNames));

            var userInput = Console.ReadLine();
            var filteringStrategy = new FilteringStrategySelector().Select(userInput);
            var result = new FilterAdvanced().FilterBy(filteringStrategy, numbers);
            Print(result);

            var words = new[] { "zebra", "ostrich", "otter" };
            var oWords = new FilterAdvanced().FilterBy(word => word.StartsWith("o"), words);
        }
        void Print(IEnumerable<int> numbers)
        {
            Console.WriteLine(string.Join(",", numbers));
        }
    }

    public class FilteringStrategySelector
    {
        //케이스에 이것저것 넣는 것 보다 각 상황이 추가될 때마다 우리는 단 한 줄의 코드 추가로 상황 변화에 대응할 수 있음!
        readonly Dictionary<string, Func<int, bool>> _filteringStrategies = new Dictionary<string, Func<int, bool>>
        {
            ["Even"] = number => number % 2 == 0,
            ["Odd"] = number => number % 2 == 1,
            ["Positive"] = number => number > 0,
            ["Negative"] = number => number <0,
        };
        //키 값에 접근하기!
        public IEnumerable<string> FilteringStrategiesNames => _filteringStrategies.Keys;

        //실제 활용되는 함수 자체는 내용 변화가 없음
        public Func<int, bool> Select(string filteringType)
        {
            //케이스 대신 딕셔너리의 것으로 대체!
            if (!_filteringStrategies.ContainsKey(filteringType))
            {
                throw new NotSupportedException($"{filteringType} is not a valid filter");
            }
            return _filteringStrategies[filteringType];
        }
    }

    public class FilterAdvanced
    {
        //필터 자체가 일반화 됨!
        public IEnumerable<T> FilterBy<T>(Func<T, bool> predicate, IEnumerable<T> numbers)
        {
            //필터 타입이 더해질 때마다 func자체를 매번 여기에서 집어넣어야 함 : 즉 새로운 형태의 필터가 나온다면..? 아래의 내용은 계속 추가되거나 수정되어야 함..
            //그렇다면... 문자를 받아 함수로 넣기 보단 함수 자체를 받아서 바로 처리한다면??
            
            var result = new List<T>();
            foreach (var number in numbers)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }
            return result;

        }        
    }
}
