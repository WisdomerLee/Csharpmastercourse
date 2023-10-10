// error : Compliation errors, Runtime error, Logical error
//exception : runtime error를 가리킴
//기본적으로 try catch finally코드가 있음!

//stack trace : error 추적! exception이 발생하기 전에 어느 메소드가 호출되었는지를 다 확인하는 것 : visual studio에서 
//기본 Exception은 모든 에러를 총괄하므로 이 에러는 여러 에러를 수집할 경우 가장 밑단으로 이동해야 함!

//Recursive method : 재귀함수의 경우... : stack over flow가 발생할 수 있음 : memory의 stack에 가득 !! : 메모리 해제 등의 상태가 없어 발생하는 상태들...

// throw new ~ : stack trace에 저장, throw ex; > stack trace에 저장되지 않고 어느 예외인지 파악할 수 없음..

//re throwing ...
//try catch는 다 좋으나 사용자가 exception을 지정하지 않으면...? 어느 에러가 발생하는지 알 수 없음!!
//global try-catch block을 쓰면...? application에서 발생하는 예외상황을 모두 처리할 수 있음!
//메인함수 내부에 try-catch를 쓰기....! 혹은 최상위 문에서
try
{
    //메인 함수의 모든 함수들...
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    //catch내부 블록에는 매우 단순히 어느 에러인지를 알려주는 간단한 로직만 작성할 것! : 최대한 단순화 해야 함
    //exception도 filter를 처리할 수 있음 when 키워드를 붙여서..
    //기본적으로 제공되는 exception을 만들 수도 있으나 사용자가 직접 exception을 만들 수도 있음.
    //모든 exception은 Exception에서 상속받은 클래스들이므로....
    //exception : method의 숨은 signature
    //너무 많은 exception은 로직의 흐름을 읽기 어렵게 만듦... : 로직의 흐름을 예외를 따져서 처리하는 것...?
    //그럼 결과를 여러 개의 형태로 만들거나 특수한 결과를 놓도록 한다면...? 그 값을 활용하는 다른 함수에서 특정 값에 대한 예외처리를 진행하여야 함
    //예외를 회피하기 위한 여러 장치들을 설치하여 예외 자체가 발생할 상황을 막는 것도 좋은 방법...
    //throw 객체 자체도 메모리를 차지한다는 것을 기억할 것!!
    //즉 exception은 아주 필요한 경우에만 쓰여야 함

    //함수 내에 쓰이는 exception은 특수 exception만 쓸 것..

}

class Cus : Exception
{
    public Cus()
    {
        
    }
    public Cus(string message) : base(message)
    {

    }
    
    
    
    
}
