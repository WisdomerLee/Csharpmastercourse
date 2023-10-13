//.Net의 메모리 관리
//리소스 해제 상황
//성능 최적화!

//.Net vs C#??
//C# : 프로그래밍 언어
//99%의 경우는 .Net의 환경에서 실행됨
//.NET은 C#으로 쓰인 어플리케이션이 실행될 수 있도록 하는 환경과 같음
//.NET 과 호환되는 다른 언어들도 있음

//F# - 함수 언어, IronPython -.NET에서 실행되는 python 코드, Visual Basic  : .NET과 호환되는 다른 프로그래밍 언어들

//.NET은 그럼 정확히 무엇??
//Common Language Runtime (CLR)을 제공하는데
//CLR은 메모리를 관리하고 에러를 처리하고 스레드를 처리하는 등의 다채로운 역할을 수행함
//또한 표준화된 라이브러리를 제공함
//using으로 쓰는 System, System.Collections등의 표준화된 함수집합을 제공함

//.NET과 관련된 프레임워크 : Windows Forms, Windows Presentation Foundation (WPF), ASP.NET MVC, .NET MAUI - .NET MAUI : 모바일, 데스크톱 앱을 통합하는 프레임워크

//.NET Framework - 2002년에 출시 : .NET으로 부름
//.NET Core -2016년에 출시 : 플랫폼에 무관하게 오픈소스로 공개
//.NET Core 5.0 -2020년에 출시 > .NET 5

//.NET 7 : C#의 11버전과 호환

//Common Intermediate Language(CIL)
//Just-in-Time compiler가 언제 어떻게 binary코드로 만드는지 알기
//C#코드가 다른 .NET-compatible language와 호출, 불러오기를 할 수 있는지 확인

//C#코드는 컴파일 과정을 거쳐 Binary code로 변화함

//C#코드는 컴파일 단계에서 Visual Studio의 빌드를 누르면 Roslyn을 불러와 컴파일이 시작됨...
//CIL code로 컴파일이 됨
//어플리케이션이 시작되면 CIL code는 JIT compiler를 거쳐 Binary code로 변화

//Just-in-Time compilation : CIL > binary code : 런타임 중에 실행
//맨 처음 실행되기 직전에 binary code로 컴파일 됨

//OS마다 기본으로 내장되어 돌아가는 프로그램이 다른데 Just-in-Time Compiler는 그 상황- OS에 맞게 binary code로 변환해주는 것
//Just-in-Time compilation : 모든 코드를 전부 컴파일 할 필요가 없음!

//사용자는 기능의 일부만 쓰고 어플리케이션을 종료할 수 있으므로 모든 것을 다 컴파일하게되면 시간과 자원을 낭비하게 됨
//

//C#, F#, Visual Basic 모두 빌드 과정에서 CIL로 컴파일되기 때문에... 서로 상호작용이 가능함!

//Common Language Runtime (CLR)
//.NET 어플리케이션을 실행할 때 그 실행환경을 관리함
//메모리 관리같이 어플리케이션의 밑단의 작업을 실행
//.NET 환경에서 실행되는 모든 프로그램을 관리

//CLR이 관리하는 것
//Just-in-Time compilation
//Memory management
//Error handling
//Thread management

//프로그래머가 코드를 작성 > 컴파일러가 CIL로 컴파일
//CLR이 프로그램을 실행, CLR의 JIT compiler가 CIL을 binary code로 컴파일
//CLR이 어플리케이션의 내부 상황을 관장


//.NET 어플리케이션이 메모리를 관리하는 방식
//Program의 메모리 : 변수를 생성하는 과정자체가 메모리에 변수의 값을 할당하는 것

//Stack : 스레드당 하나, 매우 작음 (1~4MB), 데이터와 데이터 사이의 공백이 없음, 자동으로 제거, 빠름
//Heap : 앱마다 하나, 큼, 데이터와 데이터 사이에 공백이 있을 수 있음, GC가 판단하고 지움, 느림
//Heap에서 제거되는 과정은 조금 복잡하고 시간이 걸리는 일

//value semantics, reference semantics
//value semantic : int와 같은 기본 데이터 타입

//value semantic
//=을 처리할 때 값을 복사해서 집어넣는 경우
//variable들에 저장된 값이 모두 독립적으로 처리

//reference semantics, 기본적으로 커다란 데이터 덩어리들인 클래스, 컬렉션들, variables의 값은 특정 오브젝트의 identity에 저장되고 reference라고 부름
//=을 처리할 때 참조하여 넣는 경우...> 둘이 같은 reference를 가리킴
//variable들에 저장된 값이 연계, 값이 복사되지 않고 reference 값이 복사되어 처리됨

//value type, reference type
//value type : value semantic, System.ValueType에서 파생, int, decimal, DateTime, bool등, 모든 struct
//reference type : reference semantic, System.Object에서 파생, List, object, array등, 모든 class

//value type : int a = 5; a : value를 저장
//reference type var listA = new List<int>(); listA: reference를 저장

//Local variable
//value type은 stack에 data를 저장
//reference type은 stack에 reference를 저장, heap의 data를 가리킴

//클래스 등의 값은 value타입이어도 heap에 저장!

//value type vs reference type : 언제 각각의 변수를 value, reference type으로 쓸 것인가?
//class를 struct로 바꿀 때의 변화
//immutable type을 쓸 때의 장점

//value, reference는 서로 원본에 영향이 가고 가지 않고의 차이가 있으므로 이를 주의할 것
//변수 자체가 여럿 지정되고 그 값이 변화될 때 
//입력된 파라미터가 함수로 처리될 경우

//immutable type은 value, reference type을 혼동할 때 매우 좋은 타입이 됨

//functional programming에서는 immutable type을 쓰는 것이 하나의 원칙

//ref 키워드!, out 키워드와의 차이
//value 타입인데 메서드 끝나고 나서도 그 값을 그대로 유지하고 싶다면??
//ref 키워드를 활용해보자 : 함수 선언, 함수 쓰임에 있어 ref를 반드시 써야 함
//ref로 전달되어야 하는 것은 반드시 초기화 되어야 함 : 값이 들어가거나 등등
int number = 5;
AddOneToNumber(ref number);

void AddOneToNumber(ref int number)
{
    ++number;
}

//out 키워드는?? : ref와 마찬가지로 함수 선언, 쓰임에 있어 반드시 out을 써야 함
//그리고 out이 선언된 함수는 반드시 해당 파라미터에 값을 할당하여야 함
//그리고 이 값도 메서드 끝나고 나서도 값이 유지됨
int otherNumber = 15;
MethodWithOutParameter(out otherNumber);

void MethodWithOutParameter(out int number)
{
    number = 10;
}

//ref vs out
//ref : parameter를 reference로 전달, 파라미터는 반드시 변수여야 할 필요는 없음, ref로 전달되는 파라미터는 반드시 함수로 전달되기 전에 초기화 되어야 함
//out : 메소드 내부에서 out으로 전달되는 파라미터에 값이 반드시 할당되어야 함, 파라미터는 반드시 값 타입이어야 함! 또한 이 키워드로 함수 자체 리턴 값 외에 추가적인 값을 얻을 수 있음, out으로 전달되는 파라미터는 함수로 전달되기 전에 초기화될 필요가 없음

//애초에 reference type인 것에 ref 키워드를 쓰면 ...?
var list = new List<int> { 1,2,3};

AddOneToList(ref list);

Console.ReadKey();
void AddOneToList(ref List<int> numbers)
{
    //numbers.Add(1);
    //여기서 만약 null을 넣게 시도하면??
    numbers = null;
}
//list를 확인하면 메서드가 끝난 뒤에 null이 아님을 볼 수 있음 : ref 타입이어도 해당 reference를 가리키는 값 자체는 복사되어 들어가기 때문에 나타나는 현상
//함수에 ref로 넣어 시도하게 되면 해당 원본 자체가 null이 됨!


//C#의 unified type system, 그리고 이것이 중요한 이유
//System.Object 타입을 상속받은 객체들의 모든 것을 다룰 수 있어야 함!
//어느 오브젝트건 상관없이 공통적으로 다루어야 할 때가 있음! > 드문 경우이긴 함

var variousObjects = new List<object>
{
    1, 1.5m,
    new DateTime(2024, 6, 1),
    "hello",
    //그 외 클래스 등도 넣을 수 있음
};
//내부의 데이터가 어떤 형태로 들어있는지 알 수 없는 상태에서 오브젝트를 나열하고 싶다면...?
foreach(var obj in variousObjects)
{
    //모든 오브젝트 공통 함수 : ToString(), GetType(), Equals(), 
    obj.ToString();

    Console.WriteLine(obj);
}
//GetType() : 이 함수는 해당 오브젝트가 어느 데이터 타입인지 알려줌
//object : reference type : heap에 데이터를 저장
//그런데 object에 들어가 있는 것들이 value type이어서 reference가 없는 상태라면??
//boxing이라는 과정을 통해 reference에 있는 형태로 저장할 수 있는 상태로 만들 수 있음!

//boxing, unboxing
int numberexample = 5;

object boxedNumber = numberexample;
//objcet : reference type, int : value type으로 서로 type이 다름!
//value type을 reference type으로 넣게 되면 어떤 일이 일어나는가?
//object 내부에 int 값을 가진 객체가 생성되고 heap에 저장
//즉 boxing 은 value type을 reference type의 객체로 지정할 때마다 일어나게 됨
//그러면 heap에는 value type의 값을 가진 

//object, interface, class, collection등은 모두 reference type이므로 value의 값들을 reference type으로 지정하는 순간마다 boxing이 발생

//unboxing : boxing의 과정을 거친 값이 다시 value type으로 지정될 때 일어남!
//boxing과는 달리 unboxing에서는 어느 데이터 타입으로 변경할지를 명확히 명시해야 함

int unboxedNumber = (int) boxedNumber;
//boxing은 항상 동작할 수 있으므로 비 명시적 (implicitly)
//unboxing은 object등으로 된 객체에 저장된 값이 정확히 주어진 타입과 같아야 성공할 수 있으므로 (실패 확률이 있으므로) : 명시적으로 데이터 타입을 지정하여야 함(explicitly)

//성능 상에 문제를 일으킬 수 있음!

//boxing, unboxing의 성능상 영향
//referenct의 크기
//
//만약 int의 형태의 object를 만든다고 하면??
//int a = 5;의 경우 메모리에서 차지하는 공간 : int의 크기인 4bytes를 차지
//object b =5;의 경우 메모리에서 차지하는 공간 : 새 객체를 생성하며 차지하는 공간, 메모리 할당(값), cast on unboxing : int의 크기 4bytes, 4/8bytes(reference지정 값 :32비트:4, 64비트:8), 총 크기 : 8/12bytes

//big data의 경우 boxing된 데이터로 그대로 불러오게 될 경우 몇십 GB의 메모리가 필요하게 될 수도 있음!
//interface, class의 형태로 된 데이터들 모두 reference type이므로 ...

//Garbage Collector - introduction
//어느 환경에서 garbage collector가 활동하게 되는가?
//어플리케이션의 성능에 어떤 영향이 있는가?

//프로그램의 모든 오브젝트는 lifecycle이 있음
//오브젝트가 더 이상 쓰이지 않으면 컴퓨터의 메모리에서 사라져 다른 오브젝트가 들어올 수 있는 공간을 마련해야 함
//.NET에서는 heap memory는 Garbage Collector라고 불리는 메모리 관리 메카니즘이 동작함
//Common Language Runtime의 일부분

//C언어의 경우는 오브젝트의 메모리 할당, 해제를 모두 개발자가 담당해야 함 : 관리에 실패하면?? > 메모리 누수 문제 발생
//Garbage Collector는 메모리를 즉각 지우지 않음
//개발자는 Garbage Collector가 언제 실제로 동작할지는 알 수 없음
//하지만 강제로 동작하게는 만들 수 있는데..
//GC.Collect();이 함수를 호출하면 Garbage Collector를 호출하여 즉시 실행하도록 강제할 수는 있음
//다만 이 경우는 거의 대부분 어플리케이션 만드는 코드에선 실제로 쓰이지 않음

//Garbage Collector가 동작하는 시기 : 1.operating system이 CLR에 메모리가 얼마 남지 않았음을 알릴 때
//2. 오브젝트가 heap이라는 메모리에서 차지하는 공간이 특정 기준을 넘겼을 때
//3. GC.Collect()메소드가 실행될 때 - 개발자가 GC를 호출할 경우
//실행되어야 할 때...등등의 요건으로 실행

//single core인 경우를 따져본다면
//Garbage Collector는 그 자체로는 background에서 동작하므로 thread와 독립되어 있음
//그러나 이 것이 동작할 때 다른 thread들이 동작을 멈출 수 있음!
//: 성능상의 문제를 일으킬 수 있음
//unity의 경우 single core로 동작하는데...
//오브젝트를 대량 생산해서 쏘고 파괴되는 동작이 많이 호출되면 Garbage Collector가 자주 호출되어 어플리케이션의 스레드를 멈추게 만드는 상황이 자주 발생할 수 있음

//이와 같은 성능상의 문제를 일으킬 수 있는 Garbage Collector의 문제는 여러 요인들로 자주 호출되지 않도록 설정할 수 있는데..
//자주 생성되었다가 사라지는 오브젝트의 (생명 주기가 짧은 오브젝트) : 등을 pool로 만들어 쓰면 GC의 호출로 성능이 떨어지는 것을 방지할 수도 있음!

//Garbage Collector가 동작이 끝나면 메모리는 해제됨
//그런데 이렇게 되면 메모리의 defragmentation(조각모음)가 일어나게 됨

//memory fragmentation이 무엇? 그리고 이 현상을 수정하는 defragmentation

//memory fragmentation :
//메모리는 각각의 메모리 칸이 있어 그 칸마다 데이터들을 저장하는데
//Garbage Collector가 동작하여 그 사이의 값이 사라지게 되면 (그 가운데 있는 오브젝트가 더 이상 쓰이지 않게 되어)
//데이터와 데이터 사이에 메모리 공백(데이터가 저장되지 않은 틈)이 발생함
//그렇게 되면 메모리 자체의 공간은 여유가 있어도 공간 자체들이 매우 작게 여러개로 분산되어 있어 커다란 데이터가 들어오게 될 경우 메모리에 할당할 수 없는 상태가 될 수 있음!
//빈 공백을 없애고 메모리의 빈 칸을 되도록 커다랗게 만들어주는 과정을 수행하는데(데이터들의 간격을 없앰)

//그리고 이렇게 빈 공백을 없애기 위해 오브젝트의 메모리 데이터를 옮겨주는 과정을 defragmentation이라고 부름

//Mark-and-Sweep 알고리즘 : Garbage Collector가 언제 메모리에서 오브젝트를 지울지를 결정하는 알고리즘 중에 하나
//reference counting과 그 활용의 단점

//Garbage Collector가 오브젝트를 언제 지울지 결정하는 알고리즘이 필요한데 이것이 Mark-and-Sweep 알고리즘

//Mark-and-Sweep 알고리즘은 간단히 이야기하면 reference가 있는 오브젝트들은 남기고, reference가 없는 오브젝트들은 지우는 것
//그런데 Garbage Collector는 이것을 어떻게 알 수 있는가?

//이것을 알 수 있는 방법이 여러가지가 있는데 Reference counting이 그 기법 중에 하나
//Reference counting은 reference되는 숫자를 세어 reference되는 참조의 갯수가 0이 되면 > 더 이상 다른데서 쓰이지 않으므로 필요하지 않게 됨

//그런데 순환 참조의 경우(circular reference)의 경우 다른 곳에서는 쓰이지 않아도 오브젝트 둘이 서로 상호 참조하는 상태이므로 Reference counting은 0이 되지 않음
//
//Tracing?? : object에 접근 가능한지 하지 않은지를 파악하는 것
// application roots라는 것이 필요한데 이 application root들을 통해 접근 가능한 것인지 파악함
// 어느 root들을 통해서 오브젝트가 접근가능(reachable)이되면 reachable object의 graph에 포함됨, 만약 접근가능하지 않으면? 제거

//Application roots는 그럼 무엇??
//static fields, thread의 stack의 local variable로 들어있음
//

//Garbage Collector : generations of objects
//오브젝트 세대(generations of objects)가 무엇을 뜻하고, Garbage Collector의 성능을 좋게 만드는 방법
//Large Objects Heap??
//오브젝트가 pinned 되었다는 것이 무엇을 가리키는지??

//Garbage Collector의 책임
//더 이상 필요하지 않은 오브젝트 가리기
//해당 오브젝트를 메모리에서 지우기
//메모리의 빈 칸을 조각모음하기

//오래 존재하게 되는 오브젝트의 경우는 Garbage Collector가 매번 오브젝트를 점검할 필요가 없음!
//Generations of objects
//만약 오브젝트가 2번의 Garbage Collector가 동작할 동안 살아남으면 오래 존재하는 오브젝트로 판단하여 자주 확인하지 않음

//예를 들어 linq 쿼리에 쓰이는 오브젝트는 linq가 호출되는 동안만 아주 짧은 시간 존재하는 오브젝트
//최적화가 잘 된 어플리케이션은 대부분의 오브젝트가 GC 한번의 호출에 대부분이 사라짐

//Collection of a generation : 기존의 generations들도 모두 포함

//generation 0 : 제일 처음 garbage collector에서 사라지는 것들
//generation 1 : generation 0에서는 살아남은 것들, generation 0도 모음
//generation 2 : full garbage collection : generation 0, 1, 2 모두 모음

//Large Objects Heap(LOH)
//만약 오브젝트 크기가 85000Bytes를 넘어가면 이 오브젝트들은 메모리의 특정 공간 : Large Objects Heap이라는 별도의 공간에 할당됨
//그리고 이 오브젝트들은 generation 2를 부여함 대부분 커다란 오브젝트들은 살아있는 시간이 길기 때문...

//pinned된 오브젝트들이라고도 하는데, Garbage Collector가 메모리를 모으고 조각모음을 할 때 해당 오브젝트들은 핀으로 꽂은 것처럼 이동하지 않고 살아남기 때문
//왜냐하면 큰 오브젝트는 메모리에서 이동할 때 보다 많은 리소스를 사용하기 때문..
//Garbage Collector는 오브젝트를 3단계의 generation들로 나눔 0, 1, 2

//garbage collector에서 generation 0으로 부여된 것들 중에 살아남은 것들은 generation 1로 변경
//garbage collector가 끝나고 다시 시작되었을 때 generation 1 중에 다시 살아남은 것들은 2로 변경

//이러한 오브젝트 세대 구분은 Garbage Collector의 성능을 좋게 만들어 줌

//memory leaks
//static fields가 memory leaks를 일으킬 수 있는 상황

//memory leak : 오브젝트 자체가 더이상 쓰이지 않는데도 특정 메모리 조각이 지워지지 않는 현상
//Garbage Collector : 메모리 누수를 완벽히 막을 순 없음
//대부분의 .NET 환경에서 메모리 누수를 발생시키는 것은 event들 : event에 대해 다루고 나서 접근할 예정

//또 다른 요소 : static fields
//static field와 연결되는 것은 application roots로 접근 가능한 것으로 인식되어 해당 static field가 참조하는 것들은 항상 접근가능한 오브젝트로 처리 됨
//static field를 가진 클래스 객체들 모두 !!! memory를 차지하게 되어 메모리 누수를 발생시킬 수 있음!

//destructors (finalizer) :파괴자 ??
//그리고 언제 우리가 저 파괴자를 정의해야 하는지
//destructor : 오브젝트가 메모리에서 지워지기 직전(GC)에 호출

//클래스는 모두 Finalize()함수를 갖고 있으나 이는 우리가 덮어씌울 수 없음
//대신 ~클래스이름 으로 된 파괴자를 지정하여 그곳에서 호출할 함수들을 모두 호출하면 됨

//일반적인 경우에는 파괴자는 쓰지 않음 : 심지어 권장하지 않음!!!
//오브젝트가 언제 파괴되는지 보장할 수 없기 때문...

//대신 IDisposable 인터페이스를 상속받아 Dispose 함수를 호출할 것


//Dispose method : IDisposable 인터페이스에 있는 해당 함수의 목적
//managed, unmanaged resources : 관리, 관리되지 않는 리소스??

//Dispose method : unmanaged resource를 해제할 때 쓰임
//Managed, Unmanaged
//Managed : CLR환경으로 관리, 일반적으로 개발자가 생성한 대부분의 변수, 객체 등, GC가 관리, 자동으로 해제
//Unmnanaged : CLR환경이 관리하지 않음, GC가 관여하지 않음, 직접 할당 해제해야 함!

//Unmanaged resource : database connections, file handlers, open network connections;

//

