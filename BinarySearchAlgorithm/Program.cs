//알고리즘의 성능을 측정하는 시간 계산 방식 중의 하나 시간 복잡도, 공간 복잡도로 나뉘는데
//시간은 걸리는 시간, 공간은 메모리에서 차지하는 공간을 뜻 함
//입력, 데이터 등이 늘어날 때마다 걸리는 시간, 차지하는 공간이 늘어나는 정도를 나타내는 것이 Big O
//

//Binary Search Algorithm은 대표적으로 로그 단위로 증가하는 알고리즘

//Binary Search Algorithm이 어떻게 동작하는가??
//Divide-and-conquer 전략

//가장 유명한 알고리즘이기도 함
//로그 복잡도를 설명하기 좋음
//정렬된 배열 등의 모음에서 활용하기 좋음!!

//이미 정렬된 컬렉션 등을...


//만약 찾고자 하는 것이 주어진 상태로 정렬된 배열, 리스트 등이 주어지면
//컬렉션의 가장 처음과 마지막을
//Left bound, Right bound로 지정 : 그 범위를 넘어가지 않도록...
//그럼 절반으로 자르는데..
//Left bound+ Right bound /2를 하여 나오는 index를 기준으로 나눔!
//그럼 가운데에 해당하는 (소숫점은 버림)그 원소와 찾는 것과 비교
//크면 Left bound를 가운데에 해당하는 index바로 다음으로 옮김! 작으면? Right bound를 가운데로 해당하는 index바로 이전으로 옮김...
//그리고 다시 Left bound + Right bound/2를 하여 나오는 index의 원소와 비교
//같으면 종료, 다르면 다시 크면? 작으면? 반복함
//그리고 만약 찾는 아이템이 없게 되면 ? Left bound와 Right bound의 index가 역전되는 상황이 발생...
//찾는 아이템이 있으면 Left bound = Right bound와 같은 인덱스에 머물게 됨


//Divide-and-conquer : 문제를 작게 나누어 해결을 쉽게 하는 방식...

var sortedList = new List<int>
{
    1,3,4,5,6,11,12,14,16,18
};

var indexOf1 = sortedList.FindIndexInSorted(1);
var indexOf11 = sortedList.FindIndexInSorted(11);
var indexOf12 = sortedList.FindIndexInSorted(12);
var indexOf15 = sortedList.FindIndexInSorted(15);

//아래의 경우는 내장된 BinarySearch
int indexOfBuiltin1 = sortedList.BinarySearch(1);

//기능 확장을 통해 구현해보기 : 기능확장은 static class로 구현되어야 함을 잊지 말 것
public static class ListExtensions
{
    public static int? FindIndexInSorted<T>(this IList<T> list, T itemToFind) where T : IComparable<T>
    {
        int leftBound = 0;
        int rightBound = list.Count - 1;

        while(leftBound <= rightBound)
        {
            int middleIndex = (leftBound + rightBound) / 2;
            if (itemToFind.Equals(list[middleIndex]))
            {
                return middleIndex;
            }
            else if (itemToFind.CompareTo(list[middleIndex]) < 0)
            {
                rightBound = middleIndex - 1;
            }
            else
            {
                leftBound = middleIndex + 1;
            }
        }
        return null;
    }
}
//시간 복잡도, 로그 복잡도, 성능상에서 보았을 때 좋은 점??
//그리고 이것이 이미 내장된 알고리즘은 어떻게 쓸 수 있는가?

//binary search algorithm은 입력을 절반씩 잘라서 나머지 반복을 실행함
// : log2씩 시간이 늘어남

