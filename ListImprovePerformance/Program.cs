//List를 활용할 때 성능의 향상을 높이는 방법!

//Enumerable.Range를 통해 숫자 collection을 만드는 방법!

//숫자가 길어질 때 읽기 쉽게 쓰는 방법!


//리스트에 무언가를 더할 때 : 리스트 내부 배열이 다 차기 전까지는 빠름
//배열이 모두 차서 추가로 집어넣어야 할 때 : 배열의 크기를 2배로 늘려서 다시 지정할 경우
//새 배열이 생성되고 복사된 뒤에
//Garbage Collector가 동작하여 이전 배열을 지움
//

//숫자사이에 _를 넣으면 자리 구분으로 인식하여 그냥 숫자로 인식함
var input = Enumerable.Range(0, 100_000_000).ToArray();


var list = new List<int>(); //아무런 것도 지정하지 않으면 리스트 내부 배열의 크기는 0으로 생성됨...
foreach(var item in input)
{
    list.Add(item);
}

var listAdvancedCreate = new List<int>(input); //이렇게 배열 자체를 리스트에 넣을 수도 있고... : 가장 빠른 방법!

var listAdvancedCreate2 = new List<int>(input.Length); //크기를 이미 지정하여 이만큼의 원소가 들어갈 것을 미리 지정하여 넣을 수도 있음
foreach(var item in input)
{
    listAdvancedCreate2.Add(item);
}
//그런데 한 번 늘어난 리스트의 배열은 크기가 줄지 않는데..
//만약에 그 리스트가 비게 되면....?
list.Clear();
list.TrimExcess(); //이렇게 처리하면 더이상 쓰이지 않는 배열의 빈 칸을 해방시켜 줌

//리스트를 생성할 때 배열을 그대로 복사해서 넣어줄 수 있으면 그대로 할 것
//만약 배열을 그대로 복사해서 넣을 수 없다면..
//차선책으로 리스트로 지정될 배열의 크기를 생성할 때 파라미터로 넣어줄 것

//리스트의 크기가 줄어들게 된다면 TrimExcess()함수를 호출하여 리스트에 할당된 메모리를 해방시켜줄 것!

//혹은 Add를 루프로 돌리지 말고
//AddRange()함수로 한 번에 넣을 것
list.AddRange(listAdvancedCreate2);

//리스트에서 무언가를 지울 땐... > 앞에 있는 것이 사라지면 모든 원소들을 한 칸 씩 당겨주어야 함....
//그런데 만약 여러개를 지워야 한다면?? Remove()대신
//RemoveRange()함수를 부를 것
list.RemoveRange(5, 10); //5번째부터 시작되는 10개의 원소들을 지울 것
list.RemoveAt(7); //7번째의 원소를 지울 것
list.Remove(99); //지워야 할 원소의 값을 직접 넣는 것보단.. 내부적으로 RemoveAt()함수를 호출하므로 


//Linked list : 메모리에 연속적으로 저장되지 않는 특성을 가짐
//대신 각 원소들은 다음 원소가 어느 것인지를 가리키는 레퍼런스 값을 추가로 가짐
//Node라고 불리는 요소들로 구성되는데
//각 Node는 값과 다음 Node를 가리키는 값(reference)을 가짐
//linked list의 첫번째 node : Head라고 부름
//한 방향으로만 가는 linked list가 있을 수 있고
//양 방향으로 가는 linked list가 있음

//Linked list와 List의 동작의 차이
//그리고 성능상의 차이가 어떻게 나타나는지
//그리고 언제 각각의 데이터 구조를 선택하게 되는지를 알아볼 것

//               index 찾기   맨 앞에 더하기    맨 뒤에 더하기                          데이터 지우기          메모리 사용량                     
//Linked list     O(N)          O(1)             O(N) or O(1)                               O(1)                실제 필요한 메모리 용량만 씀   각 노드는 데이터와 1개 혹은 2개의 참조 값을 가짐
//List            O(1)          O(N)             O(1) or resizing이 일어나면 O(N)           O(N)                실제 데이터보다 많이 차지 함    각 데이터는 오직 해당 데이터만 가짐

//C#에서 기본으로 제공하는 linked list는 doubly-linked list임
//만약 데이터에서 해당 위치를 쉽게 찾을 수 있어야 한다면?? list를 쓸 것
//맨 앞으로 데이터를 더하고 아이템을 지우는 일이 자주 있다면?? linked list를 쓸 것



//Dictionary의 동작이 어떻게 일어나는지 깨닫기
//Hash table은 무엇?
//그리고 GetHashCode와 Equals함수를 같이 overriding하는 것이 중요한지

//Dictionary의 데이터 구조는 기본적으로 hash table에서 유래됨
//hash table은 linked list의 배열이라고 볼 수 있음

//Dictionary를 만들면 기본적으로 빈 linked list의 배열이 생성됨
//그리고 이 곳에 키와 값으로 이뤄진 값을 집어넣게 되면
//열쇠에 해당되는 값의 GetHashCode를 얻고 index값을 hash%arrayLength;로 계산하여 넣음
//그러면 해당 index에 해당되는 곳에 linked list가 저장됨 : key : value:, Hash 3가지가 저장됨
//나머지들도 순차적으로 집어넣으면...
//그리고 만약 index가 같은 곳의 다른 hash값이 추가로 들어오면?? 그 index에 linked list가 추가되는 형식....

//그리고 hash 코드가 중복되는 값도 발생할 수도 있음!!!

//Dictionary에 값이 충분히 들어간 상태에서 데이터를 찾으려고 해보면..?
//그러면 키(열쇠) 값에 해당되는 hash 코드를 계산함
//그리고 나서 그 hash에 해당되는 index를 계산
//그러면 index에 해당되는 부분의 linked list에서 데이터를 검색!!
//linked list에서 hash값이 같은지를 먼저 확인, hash code conflict에 따라 hash값이 같은 값이 있을 수 있으므로
//다시 key 값이 같은지 확인하고 linked list에서 찾음!!!

//key값으로 바로 찾으면 매우 느리므로 먼저 hash코드로 확인하고 그 후에 key 값을 비교...
//Equals와 GetHashCode는 항상 같이 override해야 함 : 그래야 같은 오브젝트인지를 보장할 수 있음
//또한 Dictionary에 저장된 데이터들은 정렬된 상태가 아님...

//Dictionary의 성능은??
//Dictionary의 대부분의 기본 행동의 성능은 뛰어난 편
//hash code conflict가 적은 hash code를 쓸 수록 dictionary의 성능은 좋아짐

//키 값 얻기- O(1), 키가 존재하는지 확인하는 것 :O(1), 해당 키 제거 : O(1), 새 아이템 더하기 : O(1) /O(N), 값이 있는지 확인하는 것 : O(N)

//Hash set이 무엇이고 언제 쓰는가?
//그리고 collection에서 겹치는 부분을 효과적으로 제거할 수 있는 방법!
//

////만약 스펠링 체크를 하는 부분이 있다고 했을 때
//public class SpellChecker
//{
//    readonly HashSet<string> _correctWords = new()
//    {
//        "dog", "cat", "fish"

//    };
//    //만약 list로 되어있다면 포함되어 있는지를 확인하는데 시간이 오래 걸릴 것!또한 list는 중복된 값을 가질 수 있으므로 그렇게 되면 성능이 더 느려지게 됨
//    //우리는 Dictionary의 값이 필요하지 않음... 오직 그것이 있는지만 확인하고 싶을 뿐..
//    //그렇다면...?
//    //HashSet : 모든 값들이 유일하게 존재하는 값들의 집합
//    //HashSet에 같은 값을 두 번 넣게 되면 처음 들어간 값을 제외한 다른 값들은 무시됨... : 즉 중복되지 않음!!
//    //그리고 dictionary와 마찬가지로 값이 있는지 없는지 판별하는데 걸리는 시간이 짧음!!
//    //Dictionary의 성능을 갖고 싶은데 키만 있고 그 값은 필요하지 않을 때는 HashSet을 쓸 것
//    public bool IsCorrect(string word) => _correctWords.Contains(word);

//    public void AddCorrectWord(string word)
//    {

//        _correctWords.Add(word);
//    }
//}

//그럼 list에서 중복된 값을 제거할 수 있는 방법은?? 아래의 두 가지 방법으로 가능함
//var distinct = input.Distinct().ToList();
//var distinct = new HashSet<int>(input).ToList();
//성능상으로는 HashSet의 방법을 쓰는 것이 조금 더 빠르다고 함...


//Queue 가 무엇? FIFO ?
//priority queue는?

//Queue는 데이터 구조로 선형으로 데이터들이 연속적으로 나열된 상태
//그리고 데이터를 얻어오면 첫번째로 들어갔던 데이터부터 순차적으로 나옴
//First-In-First-Out : FIFO구조

var queue = new Queue<string>();
queue.Enqueue("a");
queue.Enqueue("b");
queue.Enqueue("c");
queue.Enqueue("d");

var first = queue.Dequeue();//선택과 함께 Queue에서 제거
//단순히 그 값을 얻고만 싶다면... Peek을 쓸 것!!
var second = queue.Peek();

//또한 Priority queue라는 것이 있어서
//기본적으로 데이터가 들어온 순서대로 처리되지만 중요한 것은 바로 맨 앞으로 보내는 등의 처리가 있음!!

var priorityQueue = new PriorityQueue<string, int>();
priorityQueue.Enqueue("a", 3);
priorityQueue.Enqueue("b", 4);
priorityQueue.Enqueue("c", 5);
priorityQueue.Enqueue("d", 6);

var firstPriority = priorityQueue.Dequeue();
//숫자가 낮을 수록 맨 앞에 배치됨!!!
//그리고 만약 숫자가 같으면 : 들어간 순서대로 배치

//Queue기반으로 동작하는 도구들 : Rabbit MQ, Amazon SQS, Microsoft Azure QueueStorage

//Stack이 무엇?
//LIFO??
//stack : 선형의 데이터 구조인데 차례로 쌓여있는 책과 같이 나중에 들어간 것이 제일 위에 있음
//Last-In-First-Out

//메모리의 stack 영역 : stack 데이터 구조와 같은 컨셉임!!
//또한 대부분의 programming language들의 가장 밑단에서 동작하는 메커니즘

//함수를 부른 순서등의 경우도 stack처럼 쌓이게 됨... 혹은 수학적인 계산도 마찬가지 parenthesis

//대부분의 프로그램의 취소, 혹은 뒤로가기 등도 stack을 기반으로 움직이기에 가능한 것

var stack = new Stack<string>();
stack.Push("a");
stack.Push("b");
stack.Push("c");

var top = stack.Pop(); //선택과 함께 stack에서 제거
var secondTop = stack.Peek(); //선택은 하지만 stack에서 제거하지 않음!


