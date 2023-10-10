//Generic type : 대표적인 예시 : List<> : 어느 형태의 데이터도 리스트 형태로 담을 수 있음!
//List는 내부에 배열을 갖고 있음 : 그런데 그 배열이 모두 다 차있으면??
//원래 배열보다 크기를 2배로 늘려 원래 배열을 그대로 복사해 차례로 넣고 그 뒤에 더하면 하나씩 순차적으로 더함
//중간에 하나를 지우게 된다면??
//중간의 것을 하나 지우게 되면 지운 오브젝트 빼고 나머지 배열의 원소들을 한 칸씩 당기게 됨...
// Add(T item) : 리스트에 원소를 더하게 될 때 리스트 크기가 바뀌게되는(내부 배열의 크기가 2배가 되는) 상태가 되면 시간이 오래 걸림
// RemoveAt(int index) : 리스트의 첫 원소 쪽을 지우게 되면 시간이 오래 걸림 : 모든 원소를 모두 한 칸 씩 당겨 처리해야 하므로



//리스트를 좀 더 퍼포먼스 좋게 써보기!!
//내부적으로 리스트는 4개부터 시작하여 추가로 들어오면 길이를 2배씩 늘리게 됨 > 만약 100의 리스트를 생성한다면
//4,8, 16, 32, 62, 128의 5번의 크기 확장이 일어남 : 성능에 좋은 영향을 주지 않음
//리스트를 만들 때 처음부터 크기에 대한 파라미터를 입력해주면 한 번에 해당 크기의 배열을 내부에서 만들게 됨 : 확장을 여러번 하지 않음!
//40%의 성능 향상이 있음 : Stopwatch라는 것으로 확인할 수 있음!!


//동시에 두 값을 얻어야 할 경우 : Tuple이라는 것이 있음


//public class SimpleTuple<T1, T2>
//{
//    public SimpleTuple(T1 item1, T2 item2)
//    {
//        Item1 = item1;
//        Item2 = item2;
//    }

//    public T1 Item1 { get; }
//    public T2 Item2 { get; }

//}

//Tuple은 C# system에 내장되어 있음!
//Generic이 나오기 전에 ArrayList라는 것이 있음
//object로 모든 데이터 타입을 저장할 수 있는 배열 같은 것... : object와 그 외의 타입으로 변환하는 과정은 메모리 소모를 많이 하는 과정이 있음! : boxing-unboxing
//리스트의 int값들을 모두 더하게 될 경우...? object를 모두 일일이 캐스팅 변환을 하여 더하게 됨 : 매우 느림


var countryToCurrencyMapping = new Dictionary<string, string>
//{
//    이렇게 인덱스에 키 넣는 형태로 초기화를 할 수도 있고
//    ["USA"] = "USD",
//    ["India"] = "INR",
//    ["Spain"] = "EUR",
//};
{
    //아래와 같은 {,} 묶음으로 초기화 할 수도 있음 사람이 보기에 편한 위의 방법을 많이 씀
    {"USA", "USD" },
    {"India", "INR" },
    {"Spain", "EUR" }

};
//countryToCurrencyMapping.Add("USA", "USD");
//countryToCurrencyMapping.Add("India", "INR");
//countryToCurrencyMapping.Add("Spain", "EUR");

countryToCurrencyMapping["Poland"] = "PLN";

foreach(var countryCurrencyPair in countryToCurrencyMapping)
{

}


//Dictionary : key-value pair collection
//서로 겹치지 않는 key를 갖고 있고 그 key에 할당된 값들이 있음
//일반적으로 list, array의 경우 해당 요소에 접근하려면 인덱스(몇번째)에 해당되는 값을 통해 값을 얻어냄
//Dictionary : 요소에 접근할 때 인덱스 대신 key를 씀
//Dictionary에 더해지는 키 값은 반드시 유일해야 함
//foreach로 각각 어느 값이 있는지 확인할 수 있음
//Dictionary에서 없는 키를 불러오려고 시도하면 Exception이 발생
//이미 있는 키를 더하려고 시도해도 Exception이 발생
//해당 키가 이미 있는지 확인하는 것은 ContainsKey()라는 함수를 사용할 것
//

//Strategy design pattern
