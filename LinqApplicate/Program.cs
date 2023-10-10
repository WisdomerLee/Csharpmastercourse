//LINQ가 뭐고 이걸 쓰면 무엇이 좋은지
// : 서로다른 데이터 타입에 효과적으로 적용할 수 있는 쿼리들의 모음
//Language Integrated Query
//필터, 정렬 순서, 그룹 나누기 등의 기능을 지원함


//해당 문자열이 모두 대문자로 쓰인지를 판단하는 함수 : Linq를 쓰면 단 한줄의 쿼리로 완성됨
bool IsAnyWordUpperCase_Linq(IEnumerable<string> words)
{
    
    return words.Any(word => word.All(letter => char.IsUpper(letter)));
}
//Linq의 경우는 결과를 쓸 때만 사용됨!!


var words = new List<string> {"a", "bb", "ccc", "dddd" };
//글자가 2개 초과인 문자열만 남기기
var wordsLongerThan2Letters = words.Where(word => word.Length > 2);

var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
//홀수만 남기기
var oddNumbers = numbers.Where(number => number % 2 == 1);

//Where라는 메서드를 통해 주어진 리스트, 배열등에서 조건식을 만족하는 것들만 선택할 수 있음!!

//IEnumerable<T>인터페이스 : 배열, 리스트, HashSet, Dictionary등의 컬렉션 타입이 모두 상속받아 쓰는 인터페이스!
//해당 인터페이스를 상속받으면 foreach문을 이용하여 각각의 원소를 끄집어낼 수 있다!!
//Linq의 메서드들은 입력된 컬렉션 자체를 변경하지 않음!


var numList = new List<int> { 5, 3, 6, 1, 8, 4 };
//List의 Add가 아닌 Linq의 Append로 원소를 추가하게 되면?? > 원본은 그대로 두고 새 컬렉션을 복사해 만든 뒤에 그 곳에 원소를 추가함!
var numbsersWith10 = numList.Append(10);

//Linq의 메서드들은 IEnumerable<T>를 입력으로 받고, IEnumerable<T>를 돌려줌!
//즉 Linq메서드를 체인처럼 연속적으로 쓸 수도 있음
//첫번째 where로 원소들을 선택하고 > Orderby로 정렬된 값을 얻을 수 있음
var orderedOddNumbers = numList.Where(number => number % 2 == 1).OrderBy(number => number);

//Deferred execution : 이것은 Linq의 표현식을 값이 실제로 필요할 때까지 미루는 것임 : 즉 필요 없으면 굳이 실행하지 않음 : 실행될 때만
//.ToList()나 ToArray()로 바꾸지 않는 한 원본 데이터가 바뀔 때마다 쿼리 값이 바뀌어 출력됨

//Any method : 컬렉션의 어느 데이터 중에 하나라도 람다(혹은 함수) 식의 조건을 만족하면 ??
//Any()로 쓰게 되면 빈 컬렉션이 아닌 이상 True를 돌려줌

//All : 모든 원소들이 모두 조건을 만족해야 True를 돌려줌

//Count, LongCount: 조건을 만족하는 원소들의 갯수 세기!
var largerthan5 = numList.Count(number => number > 5);

//Contains메서드를 링크에서 쓰기!
var isContains3 = numList.Contains(3);

//OrderBy, OrderByDescending, ThenBy, ThenByDescending 메서드!
var orderbynumber = numList.OrderBy(number => number);
var orderbyDescendingNumber = numList.OrderByDescending(number => number);

//ThenBy는 만약 OrderBy로 정렬하고도 만약 같은 순위에 있는 것들이 있을 때 2번째 기준으로 이 기준으로 정렬할 것을 뜻함!!
//(클래스의 기준을 일단 rate기준으로 나누고 그 뒤에 가격순으로 나열한다거나.. 등)

//First, Last = 해당 리스트의 가장 첫번째, 마지막을 반환함!
//그런데 만약 해당 기준으로 고른 부분이 빈 컬렉션이 될 경우엔...? First(), Last()메서드는 에러를 띄움!
//그럴 경우를 대비하여 FirstOrDefault, LastOrDefault메서드를 활용하자!

//Where : 원본 컬렉션에서 특정 원소들이 조건을 만족하는 리스트를 추가로 만들 때 쓰임!
//추가로 Where로 기준에 맞는 부분이 하나도 없으면 빈 컬렉션을 반환함!!

//Distinct : 컬렉션에서 중복되는 모든 값을 제외하여 모든 원소가 유일하도록 바꾸어 줌!

//Select method : 람다 식으로 지정된 식을 각 컬렉션의 모든 원소에 대응시킴!
var doubledNumbers = numList.Select(number => number * 2);
//해당 람다의 식이 모든 원소에 적용
//또한 Select로 데이터의 타입도 바꿀 수 있음...
//그 외에 원하는 형태의 문자열 형태로도 데이터를 바꿀 수 있음!

//Average value계산하기 와 anonymous types :
//숫자 타입으로 된 것들에 적용 가능...

var listsOfNumbers = new List<List<int>>
{
    new List<int>{15, 6, 653, 32,3,2},
    new List<int>{12, 1, 5, 6},
    new List<int>{4, 10, 11, 23}
};

//튜플을 쓰면 Item1, Item2라는 코드를 짠 사람 외에는 알 수 없는 파라미터 이름으로 접근하게 됨...
//var result = listsOfNumbers.Select(listOfNumbers => new Tuple<int, double>
//(
//    listOfNumbers.Count(),
//    listOfNumbers.Average()
//))
//    .OrderByDescending(countAndAverage => countAndAverage.Item2)
//    .Select(countAndAverage => $"Count is : {countAndAverage.Item1}," +
//    $"Average is {countAndAverage.Item2}");

//Anonymous Type을 만들어 쓸 수도 있음!! : 다만 여러곳에 쓰이는 경우라면 class를 만들어 쓸 것 > 그렇지 않고 Query 한 곳에서 쓰는 것이라면? 단일 anonymous type을 만들기!
//Anonymous Type은 Linq에서만 쓸 수 있음...
var result = listsOfNumbers.Select(listOfNumbers => new
{
    Count = listOfNumbers.Count(),
    Average = listOfNumbers.Average()
})
    .OrderByDescending(countAndAverage => countAndAverage.Average)
    .Select(countAndAverage => $"Count is : {countAndAverage.Count}," +
    $"Average is {countAndAverage.Average}");


//public class CountAndAverage
//{
//    public int Count { get; init; }
//    public double Average { get; init; }
//}

//Ctrl+Shift+F를 누르면..? 찾기 및 바꾸기 창 바로가기가 뜸
