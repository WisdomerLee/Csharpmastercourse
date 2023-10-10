/*
 * abstraction 레벨
 * 
 * 객체 지향 프로그래밍을 해야 하는 이유 ? : 유지 보수성, 가독성(이해성), 등을 높이기 위함
 * abstraction : 필요한 기능 외에 숨기기 기능
 * 데이터 숨기기가 왜 중요한 것인가??
 * : 아무데서나 데이터에 접근하여 수정하게 된다면....?
 * Top-level statements :??
 * 데이터만 포함하는 것, 데이터를 처리하는 부분이 나뉘는 것
 * method overloading : 메소드 이름 자체는 같으나 입력, 반환 값이 다를 경우....
 * 만약 메소드의 내용이 단 한 줄의 expression이라면..?
 * 
 */

public class Rectangle
{
    int width;
    int height;

    public Rectangle()
    {
        string type = width switch
        {
            int i when i <5 =>"tiny",
            int i when i >=5 && i < 30 => "",


        };
        
    }

    //변수 중 하나는 선택적으로 필요한 경우일 때... 어떻게 처리할 것인가??
    //변수의 값을 제공하지 않으면 함수 내부에서 처리한 기본 값으로 처리..
    //변수의 값이 제공되면 그 제공된 값을 함수에서 처리
    //또한 선택적으로 적용되는 변수는 반드시 모든 필수로 들어가야 하는 파라미터 다음으로 들어가야 함!!!
    //const : 프로그램 실행 중에 변경될 리가 없는 것들 : 어떤 일이 있어도 변경되지 않음
    //readonly : 생성자로 한 번 값이 지정된 이후에 변경되지 않음 : 런타임 중에 값이 바뀔 수 있음 (생성될 때)
    //필드의 경우 일반적으로 변경하거나 그 값을 얻을 때 매번 public으로 노출시키면 값을 무작위로 바꿀 수 있는 상황이 올 수도 있음...
    //프로퍼티 : 필드의 값을 읽거나 변경하는 특수 메서드 : getter, setter : 각각의 설정을 public, private으로 바꾸어 읽는 것은 public, 설정하는 것은 private 혹은 그 반대로도 설정할 수 있음
    //프로퍼티: 메소드 기반..
    //필드는 private으로 해두는 것이 좋음
    //프로퍼티는 public인 경우가 많음!
    
    //생성자로 property를 지정하려면 모든 파라미터의 내용을 다 들고 있어야 함...
    //먼저 아이템을 만들고 나중에 값을 지정하고 그 뒤에 값을 수정할 수 없게 만들고 싶다면??
    //init을 쓰자!! : set은 언제나 설정할 수 있지만 init은 값이 설정된 이후엔 추가 설정을 할 수 없게 함
    //computed propety : parameterized method
    //property는 performance상으로 무겁지 않아야 함..
    //또한 property가 자주 호출되고 계산되는 상태라면 메소드 형태로 만들어야 함...
    //property는 매우 빠름
    //static class : static method만 가짐 + 필드가 없고 오직 메서드만 가짐
    //일반 class : static method도 가질 수 있음
    //객체 자체는 의미가 없고 메서드의 행동이 모두 같을 때 static으로 설정할 것 : 예를 들면 파일 불러오기, 저장, 혹은 계산 과 같은 것들...
    //static constructor : 클래스의 어떤 객체도 생성되기 전에 실행됨 - 언제 생성될지 알 수 없음

    public string Item
    {
        get;
    }
    public void CheckOption(int width= 0)
    {
        
    }

    public Rectangle(int width, int height)
    {
        //this : 변수 이름이 같을 경우 this.으로 하게 되면 내부 변수, 쓰지 않을 경우 입력으로 들어온 변수를 가리키게 됨
        this.width = width;
        this.height = height;
    }
    //메소드 내용이 단 한줄의 expression일 경우에만 아래와 같이 쓸 수 있음!!
    public int CalculateCircumference() => 2*width + 2*height;
    public int CalculateArea() => width*height;
    
}
