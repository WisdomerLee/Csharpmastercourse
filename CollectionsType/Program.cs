//Collections!!!
//Collections : 서로 연관이 있는 오브젝트들을 저장하고 가공하는 방식을 제공
//collections는 기본적으로 특정한 interface를 내장하고 있고 그 interface는 collection들의 가공 방식을 제공함

//IEnumerable > ICollection > IList
//가장 보편적인 interface : IEnumerable임
//IEnumerable : foreach로 collections에 접근할 수 있는 방법을 제공

//string : 기본 데이터 형이나 collection 기능을 가짐!!

using System.Collections;

var customCollections = new CustomCollection(new string[] { "aaa", "bbb", "ccc" });
foreach (var item in customCollections)
{
    Console.WriteLine(item);
}

//IEnumerable interface에 들어있는 함수 : IEnumerator GetEnumerator()함수가 들어있음
//그리고 collection의 원소를 변경하는 함수는 없음!
//IEnumerator - collection에서 콜렉션을 왕복하며 요소마다 함수를 반복하여 불러올 수 있게 함



//IEnumerator - object Current{get;} bool MoveNext(), void Reset() 의 프로퍼티 1개, 함수 2개를 가짐
//foreach로 오브젝트를 출력하던 뭐하던 간에 그것이 지나고 나면 current는 다음 오브젝트를 가리키게 됨
//그리고 다음 요소가 없으면 MoveNext()함수가 false를 반환하고, 그 순간이 되면 foreach문이 종료됨
//종료되는 순간 Reset()함수가 호출되어 Current가 처음으로 되돌아감
var words = new string[] { "aaa", "bbb", "ccc" };
//foreach내부에서 일어나는 일 : 
IEnumerator wordsEnumerator = words.GetEnumerator();
object currentWord;
while (wordsEnumerator.MoveNext())
{
    currentWord = wordsEnumerator.Current;
    Console.WriteLine(currentWord);
}
//위의 코드는 아래의 코드와 완벽히 같은 일을 함
foreach (var item in words)
{
    Console.WriteLine(item);
}



//IEnumerable<T> 를 구현하기 위해 필요한 함수들
//implicit, explicit interface 구현

//일반적인 IEnumerable과 IEnumerable<T>의 차이는 IEnumerator<T>로 돌려준다는 것...과 IEnumerable<T>는 IEnumerable을 상속받는다는 것이 차이



//커스텀 컬렉션 클래스를 선언하고 그것을 그냥 foreach문으로 돌리려고 하면?? 컴파일 에러 발생..!! : foreach로 접근하는 방법이 제공되지 않기 때문.. : IEnumerable 인터페이스를 구현해야 foreach를 쓸 수 있음

Console.WriteLine();
//커스텀 컬렉션에서 indexer를 쓰려고 시도해보면..? : 그냥 시도하면 indexer가 없어 에러가 남..
var first = customCollections[0];
//customCollections[1] = "abc";



//Collection Initializer를 custom collection에 넣을 방법
//collection initializer는 다음과 같은 경우
//var list = new List<int>(10){ 2, 5, 3, 6 };

//등의 방법으로 새 객체를 만들면서 collection의 값들의 초기 값을 미리 지정하여 넣어줄 수 있음

//collection 초기화의 방법을 쓰려면 파라미터 없는 기본 생성자가 하나 있어야 하고..
//또한 그 값에 더하는 Add()함수가 있어야 함
//



//ICollection, IList인터페이스를 살펴봅시다..
var numbers = new List<int> { 1, 3, 5, 2, 6, 7, 8 };
var array = new int[10];
numbers.CopyTo(array, 2);
//위와 같이 복사하면 배열의 0, 1번째를 건너뛰고 2번째부터 리스트의 모든 원소들을 복사해와서 붙여넣음!
//그리고 배열이 더 짧으면? 배열 범위를 벗어나기 때문에 에러가 발생함...
//그리고 리스트를 만드는 또 다른 방법은 배열 자체를 입력으로 넣어줄 수도 있음!!!
var numberArraytoList = new List<int>(new int[] {1,2,3});

//IList를 구현하려면...? 상속받은 모든 인터페이스의 함수들을 구현해야 함...
//그런데... 특수한 상황의 경우엔 (크기가 고정되어있다거나..) 등의 경우엔??
//interface를 구현하는데 몇몇 함수의 경우엔 구현이 불가능할 경우... 어떻게 처리하면 될까??

//그 전에 배열을 reflection을 통해 확인해보기
var implementedInterfaced = array.GetType().GetInterfaces();

//배열을 확인해보면 ICollection의 interface도 상속받음을 확인할 수 있음
//그런데 ICollection에는 Add함수가 포함되어있으므로 배열에도 Add 함수를 쓸 수 있어야 함
//하지만 실제로 배열에 Add함수를 쓰려고 시도하면 컴파일 에러가 남
//어떻게 가능한 것일까??

ICollection<int> arrayAsCollection = array;
//이 형태로 Add함수를 부르면 컴파일 단계에서는 무사하나 실행단계에서 에러가 남

//Interface Segregation Principle - 사용하지 않는 함수를 의존하도록 강제하면 안 됨
//특정 클래스에 인터페이스를 구현할 때 해당 클래스에 맞지 않는 함수들은 구현을 강제할 수 없음...

//인터페이스를 되도록 작게 나누고...

//immutable type, immutable collections : immutable type을 쓸 때의 장점과 같음

//그럼 collection을 읽기 전용으로 만드는 방법은??
//ReadOnlyCollection!!으로 생성할 것
var dictionary = new Dictionary<string, int>
{
    ["aaa"] = 1,
};
var readonlyDictionary = new System.Collections.ObjectModel.ReadOnlyDictionary<string, int>(dictionary);
//readonlyDictionary.Clear();
//readonlyDictionary["aaa"] = 2;
//읽기, 지우기, 등의 행동 자체가 막힘!!!


public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }


    #region 컬렉션 초기화에 필요한 부분
    //파라미터 없는 기본 생성자
    public CustomCollection()
    {
        Words = new string[10];
    }
    //
    int _currentIndex = 0;
    //그리고 컬렉션에 더하는 함수가 필요함!
    public void Add(string item)
    {
        Words[_currentIndex] = item;
        ++_currentIndex;
    }
    #endregion

    //아래와 같은 표현 법이 explicit implementation : 그리고 이와같이 표현하면 public, private과 같은 한정자를 쓰면 안 됨..
    //또한 explicit implementation의 기법으로 함수가 구현되면 객체를 통해 직접 호출하는 interface 함수로는 아래의 함수를 호출 할 수 없고
    //오직 interface객체를 따로 선언하여 그 객체에 해당 객체를 집어넣고 그 interface 객체로 호출해야 함...
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    //IEnumerable <T>는 IEnumerable을 상속받기 때문에 IEnumerable의 인터페이스 함수와 IEnumerable<T>의 함수 모두 구현해야 함!!
    //explicit interface implementation이 필요
    //같은 이름의 같은 파라미터를 가진 함수를 서로 다른 인터페이스를 상속받아 구현해야 할 경우
    //아래와 같은 표현 법이 implicit implementation
    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    //indexer를 구현해보자!! : indexer를 쓰고 tab을 두 번 누르면?? : 코드를 자동 생성해줌! try와 마찬가지.. : 아래의 indexer를 구현해야 .. 숫자 등으로 요소에 접근 가능!!
    //꼭 숫자여야 할 필요는 없음!
    //Dictionary의 자료형을 가진 구조에서는 key값으로 string이 들어갈 수도 있는데 그럴 땐 indexer를 string으로 구성하면 됨..
    //일반적으로 indexer에는 getter만 있어 읽기 전용으로 쓰는 경우가 많음

    public string this[int index]
    {
        get => Words[index];
        //set => Words[index] = value; : setter를 없애면?? 읽기 전용의 indexer가 됨
    }


}
//Implicit : 해당 interface를 상속받은 클래스 자체 객체로 만든 뒤에 함수 호출 : CustomCollection c... = c.GetEnumerator();
//explicit : 해당 interface 자체의 객체로 만든 뒤에 상속받은 클래스 객체로 지정하고 함수 호출 : IEnumerable x... = x.GetEnumerator();
//그래서 explicit로 구현할 경우 접근한정자가 의미가 없음.. 오직 interface를 통해서만 접근 가능

//IEnumerable<T> 인터페이스 구현 방법
//backward compatibility ??
//named argument ??


//backward compatibility : 이후의 버전의 코드가 이전 코드에서도 동작할 수 있도록 하는 것!!!
//이전 버전에서 작성한 코드는 이후 버전에서 동작을 잘 함
//그럼 그 반대는...?

//indexers는 뭘까??
//custom indexer 지정 방법

////Collection에 특정 위치에 있는 요소에 접근할 때 indexer를 씀!!
//또한 Dictionary에 있는 key들도 일종의 indexer와 같은 것!!
//꼭 숫자만 지정할 필요는 없다는 것



public class WordsEnumerator : IEnumerator<string>
{
    const int InitialPosition = -1;
    int _currentPosition = InitialPosition;
    readonly string[] _words;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    object IEnumerator.Current => Current;


    public string Current
    {
        get
        {
            //try를 치고 탭을 두 번 누르면 자동완성이 됨!!!
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}의 끝에 도달함", ex);
            }
        }
    }


    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = InitialPosition;
    }

    public void Dispose()
    {

    }
}

public class A<TLeft, TRight>
{
    TLeft[] _left;
    TRight[] _right;
    public (TLeft, TRight) this[int index1, int index2]
    {
        get => (_left[index1], _right[index2]);
    }
}
