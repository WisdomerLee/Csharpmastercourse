using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImprovePerformance
{
    internal class YieldState
    {
        //yield
        //언제 유용한지
        //그리고 yield의 동작과 그 행동 분석
        //yield statement를 이해하기



        void Main()
        {
            //매우 큰 데이터 단위에서 특정 부분만 쓰고 싶음...
            var smallSubSet = GenerateEvenNumbers().Skip(5).Take(10);
            //매우 큰 컬렉션이 함수가 동작할 때마다 생성됨... 그 극히 일부만 쓰고 있음에도..
            //리소스 낭비가 심함
            //그럼 모든 컬렉션이 다 완성되기 전에 필요한 데이터만 다 얻으면 중단되게 할 수 없을까??
            var firstEvenNumber = GenerateEvenNumbers().First();

            //yield 가 포함된 return이 들어간 순간 매우 많은 루프를 다 돌지 않고 빠져나옴...
            //그리고 첫번째 값을 얻자마자 바로 메서드가 종료됨을 확인할 수 있음
            //
            //yield statement가 동작하는 방식
            //iterator의 원리

            //IEnumerable은 collection이 아닌, foreach loop로 돌릴 수 있는 것임을 알려줌
            //iterator : 어느 아이템의 연속적인 묶음을 만들어 낼 수 있는 객체
            //iterator : 요소들의 연속적인 순서를 생산하는 가이드라인이 있고 얼마나 진행되었는지를 기억함...
            //
            //단순히 아래의 함수를 호출만 하면... loop쪽의 breakpoint에 걸리지 않음
            //iterator를 생성하고 종료되기 때문


            var arraystring = new string[] { "a", "b", "c", "d", "b", "d", "" };
            foreach (var item in Distinct(arraystring))
            {
                Console.WriteLine(item);
            }

            var numbers = new int[] { 1, 2, 4, 6, 7, -3, 8, -2 };
            foreach (var number in GetBeforeFirstNegative(numbers))
            {
                Console.WriteLine(number);
            }

        }
        //아래의 함수는 iterator를 돌려주는 함수
        //함수가 iterator를 돌려주게 만들려면 조건이 2가지 필요함
        //IEnumerable/IEnumerator를 돌려주어야 하고
        //그 함수 내부에서 yield statement가 있어야 함
        //또한 Linq 함수들 또한 iterator를 생성하므로 여러 번 호출하면 여러 iterator가 생성되어 동작함
        //이것은 iterator를 ToList()등으로 객체로 만들어주어야 반복하지 않게 됨...
        IEnumerable<int> GenerateEvenNumbers()
        {
            for (int i = 0; i < int.MaxValue; i += 2)
            {
                yield return i;
            }
        }
        //iterator를 실용적으로 쓰는 방식
        //yield break statement의 목적

        //iterator는 같은 루프 안에서는 항상 그 이전에서 끝난 다음을 호출하게 됨(자동으로)

        IEnumerable<T> Distinct<T>(IEnumerable<T> input)
        {
            var hashSet = new HashSet<T>();
            foreach (var item in input)
            {
                if (!hashSet.Contains(item))
                {
                    hashSet.Add(item);
                    yield return item;
                }
            }
        }

        IEnumerable<int> GetBeforeFirstNegative(IEnumerable<int> input)
        {
            foreach (var number in input)
            {
                if (number >= 0)
                {
                    yield return number;
                }
                else
                {
                    yield break; //iterator에 기존에 기억했던 위치를 제거하라고 하는 것...?
                }
            }
        }
        //마지막 눌을 만나기 전에 역순으로 출력하기...
        IEnumerable<T> GetLastAfter<T>(IList<T> input)
        {
            for (int i = input.Count - 1; i >= 0; i--)
            {
                if (input[i] is null)
                {
                    yield break;
                }
                yield return input[i];
            }
        }

        //IEnumerable interface를 iterator를 이용하여 구현하기
        //IEnumerable interface를 구현하기 위해서는 IEnumerator를 돌려주는 경우를 만들어야 하고, 그 IEnumerator를 돌려주는 별도의 클래스를 따로 만들어야 했음!
        //

    }
    //Custom Linked List : double, single linked list
    //Node 그 자체와 Linked list 2가지를 구현해야 함

    //
    interface ILinkedList<T> : ICollection<T>
    {
        void AddToFront(T item);
        void AddToEnd(T item);
    }
    class SinglyLinkedList<T> : ILinkedList<T?>
    {
        Node? _head;
        int _count;
        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T? item)
        {
            AddToEnd(item);
        }

        public void AddToEnd(T? item)
        {
            var newNode = new Node(item);
            if (_head is null)
            {
                _head = newNode;
            }
            else
            {
                var tail = GetNodes().Last();
                tail.Next = newNode;
            }
            ++_count;
        }

        public void AddToFront(T? item)
        {
            var newHead = new Node(item)
            {
                Next = _head
            };
            _head = newHead;
            ++_count;

        }

        public void Clear()
        {
            //루프를 통해 반복작업이 진행되는 콜렉션을 수정하는 것은 대개 좋지 않은 결과(예상치 않은 결과)를 가져옴
            Node? current = _head;
            while (current is not null)
            {
                Node? temporary = current;
                current = current.Next;
                temporary.Next = null;
            }
            //foreach로 list를 만들어서 루프를 돌릴 수도 있으나...
            //그렇게 하면 지울 때 리스트를 만들어서 지워야 하므로 메모리 차지 공간이 불필요하게 추가됨...

            _head = null;
            _count = 0;
        }

        public bool Contains(T? item)
        {
            if (item is null)
            {
                return GetNodes().Any(node => node.Value is null);
            }
            return GetNodes().Any(node => item.Equals(node.Value));
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if(array.Length < _count + arrayIndex)
            {
                throw new ArgumentException("Array is not long enuogh to copy ");
            }
            foreach (var node in GetNodes())
            {
                array[arrayIndex] = node.Value;
                ++arrayIndex;
            }
        }


        public bool Remove(T? item)
        {
            Node? preprocessor = null;
            foreach (var node in GetNodes())
            {
                if ((node.Value is null && item is null) || (node.Value is not null && node.Value.Equals(item)))
                {
                    if (preprocessor is null)
                    {
                        _head = node.Next;
                    }
                    else
                    {
                        preprocessor.Next = node.Next;
                    }
                    --_count;
                    return true; //루프를 도는 중에 콜렉션이 바뀌면 안 되는 상황이나 이 경우엔 콜렉션이 바뀌고 나서 루프를 끝냄...!
                }
                preprocessor = node;
            }
            return false;
        }
        public IEnumerator<T?> GetEnumerator()
        {
            foreach (var node in GetNodes())
            {
                yield return node.Value;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerable<Node> GetNodes()
        {
            Node? current = _head;
            while (current is not null)
            {
                yield return current;
                current = current.Next;
            }
        }

        //linked list에 쓰일 노드 : : 어느 글자를 전체를 바꾸고 싶다면? 드래그한 뒤에 Ctrl+H키를 눌러볼 것 : 전체 바꾸기가 됨
        private class Node
        {
            public Node(T? value)
            {
                Value = value;
            }

            public T? Value { get; }
            public Node? Next { get; set; }

            public override string ToString() => $"Value: {Value}, Next: {Next}";

        }
    }


    

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
            //return new WordsEnumerator(Words);
            //아래와 같이 yield return statement가 존재하여 IEnumerator를 구현함!
            //foreach(var word in Words)
            //{
            //    yield return word;
            //}
            //혹은 아래와 같이..
            IEnumerable<string> words = Words;
            return words.GetEnumerator();
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
    //Tuple로 돌려주기....
    public class A<TLeft, TRight>
    {
        TLeft[] _left;
        TRight[] _right;
        public (TLeft, TRight) this[int index1, int index2]
        {
            get => (_left[index1], _right[index2]);
        }
    }
}
