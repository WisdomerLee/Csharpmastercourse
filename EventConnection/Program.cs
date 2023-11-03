
//Event 
//오브젝트 간에 특정 알림 보내기
//새 Design pattern
//Event와 메모리 누수

//객체 간 커뮤니케이션이 필요한 이유

//소프트웨어에서 들어간, 혹은 만들어진 객체들간 알림 보내는 방법

//많은 program에서 Event > 알림(이벤트 동작 알림) > 객체 행동
//과 같은 일들이 일어남..
//특정 이벤트로 촉발되는 행동들이 있음


//notification mechanism
//객체를 직접 참조하여 함수를 부르는 방식은...?
//커플링이 매우 심하고 또한 그 값을 바꾸게 될 경우... > 건드려야 할 곳이 여러 곳...

//이벤트를 동작시키는 클래스와 그 이벤트의 알림을 받는 클래스간 커플링 완화
//알람을 등록해야 하는 것이 쉬워야 함...등이 있음
//또한 특정 객체에 알림을 보내는 것을 중지하는 것도 있어야 함
//위의 조건들을 만족시키는 것 : Observer Design Pattern

//Observer design pattern
//Observer design pattern은 객체가 다른 오브젝트에 그들의 상태가 바뀌었음을 다른 곳에 알리는 것이 가능함

//상태가 바뀌는 것 : Observable, 그리고 그 상태가 바뀐 것에 대응하는 것들 : Observer
//원래라면 Observer design pattern의 경우 : interface를 생성하여 Observable, Observer에 할당하고 그 알림을 알려야 하는데




//interface IObserver<TData>
//{
//    void Update(TData data);
//}

//interface IObservable<TData>
//{
//    void AttachObserver(IObserver<TData> observer);
//    void DetachObserver(IObserver<TData> observer);
//    void NotifyObservers();
//}

//public class EmailPriceChangeNofifier : IObserver<decimal>
//{
//    readonly decimal _notificationThreshold;

//    public EmailPriceChangeNofifier(decimal notificationThreshold)
//    {
//        _notificationThreshold = notificationThreshold;
//    }

//    public void Update(decimal price)
//    {
//        if (price > _notificationThreshold)
//        {

//        }
//    }
//}

//public class GoldPriceReader : IObservable<decimal>
//{
//    int _currentGoldPrice;
//    readonly List<IObserver<decimal>> _observers = new();
//    public void NotifyObservers()
//    {
//        foreach (var observer in _observers)
//        {
//            observer.Update(_currentGoldPrice);
//        }
//    }

//    void IObservable<decimal>.AttachObserver(IObserver<decimal> observer)
//    {
//        _observers.Add(observer);
//    }

//    void IObservable<decimal>.DetachObserver(IObserver<decimal> observer)
//    {
//        _observers.Remove(observer);
//    }
//}

//C#에 있는 내장된 메카니즘 event가 있음!
//event를 정의하는 방법
//그리고 event를 구독하는 방법
//

//.NET의 환경에서 observer design pattern이 event로 쓰임
//객체에 뭔가 일어났다는 것을 알릴 수 있고
//이 이벤트의 기본은 delegate를 이용하는 것

//delegate는 특정한 타입 중 하나, class, struct같이..
//delegate의 타입은 그곳에 지정할 수 있는 함수를 지정하는데 delegate에서 지정한 signature가 같은 함수를 넣을 수 있음
//delegate타입은 여러 함수들의 reference를 저장함(저장할 수 있는 함수들은 매개변수 종류, 갯수, 돌려주는 타입이 모두 같음)

Method methods = Test1;
//아래와 같이 더하거나
methods += Test3;
//뺄 수도 있음
methods -= Test3;

methods(5);



void Test1(int number) { }
void Test2(int number) { }
void Test3(int number) { }

public delegate void Method(int a);

//매우 중요한 요소인데
//event를 갖고 있는 클래스, 그리고 해당 event는 public으로 선언되어야 함!
//그래야 다른 객체에서 event에 구독, 혹은 해지를 할 수 있음

//그럼 이벤트는 어떻게 발생시키는가?
//Invoke함수의 목적
//(?.)operator의 목적
//이벤트에 들어간 함수가 하나도 없으면?? null exception이 발생함!
//그럼 ...
//Invoke함수는 이벤트에 들어간 함수를 모두 발생시키기 때문에 그냥 이벤트 함수를 자체 실행하는 것과 같은 효과를 냄... 그럼... 왜 쓰는가??
//null exception을 방지하기 위한 방법으로
//?.Invoke()로 발생시키면... > null일 경우에는 함수가 동작하지 않음!!!
//

//EventHandler delegate를 쓰는 방법
//EventArgs는 무엇?

//CustomEventArgs를 선언하고 (EventArgs를 상속받아야 함)
public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }
    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}

public class GoldPriceReader
{
    public event EventHandler<PriceReadEventArgs>? PriceRead;


    void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(this, new PriceReadEventArgs(price));
    }
}

//event와 delegate type의 멤버의 차이
//둘 다 함수를 더할 수 있고, 함수를 제거할 수 있는 것은 같음

//차이라면 event는 오직 event가 있는 클래스 객체에서만 호출 가능, delegate type은 null이라는 객체를 집어넣어 다른 객체에서도 호출 가능함...

//event를 쓸 때는 메모리 누수에도 신경써야 함
//C#에서 가장 흔한 메모리 누수는 이벤트와 연관되어 있음
//만약 이벤트를 구독하고 있던 오브젝트가 계속 생성되는 형태라면...?
//그리고 이벤트 구독이 해지되지 않는 상태라면 ? 해당 이벤트는 계속 참조를 들고 있게 됨...


