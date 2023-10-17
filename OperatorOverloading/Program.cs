//operator overloading
//+, ==, != operator등을 덮어씌우는 방법
//덮어씌울 수 있는 연산자, 덮어씌울 수 없는 연산자
//일반적으로 Equals()함수는 기본적으로 어느 타입이든 쓸 수 있음
//그리고 함수의 경우는 사용자가 임의로 지정하여 쓸 수 있으므로 사용자가 정의한 함수를 쓰기만 하면 됨
//그러나 +, ==, != 등의 연산자는 타입에 따라 쓸 수 있기도 하고 없기도 함
//

readonly struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }
    public Point(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }
    public override string ToString() => $"X: {X}, Y: {Y}";
    public override bool Equals(object? obj)
    {
        return obj is Point other && Equals(other);
    }
    //하지만 보다 특수한 형태로 object 대신 아래와 같이 쓴다면??
    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }
    //+ operator 덮어씌우기 : 연산자 덮어씌울 때는 static 키워드와 함께 적용 필요!
    public static Point operator + (Point left, Point right) => new Point(left.X + right.X, left.Y + right.Y);
    //그리고 operator의 양쪽에 들어갈 것을 정의하고....
    //== operator를 정의하려면 != operator도 정의해야 함!! : 반드시 짝을 이루어야...
    public static bool operator == (Point point1, Point point2) => point1.Equals(point2);
    public static bool operator != (Point point1, Point point2) => !point1.Equals(point2);
    //데이터 변환! > Point > Tuple로 implicit conversion
    public static implicit operator Point(Tuple<int, int> tuple) => new Point(tuple.Item1, tuple.Item2);
    //아래는 explicit conversion을 할 경우..
    //public static explicit operator Point(Tuple<int, int> tuple) => new Point(tuple.Item1, tuple.Item2);
    //어느 conversion을 쓸지는 본인의 선택에 따라...
}

//연산자의 대부분은 overload가 가능하나 가능하지 않은 것들도 있음
//=>, . , new, &&, || 등의 연산자등은 overload가 불가능!

//implicit, explicit conversion operator 가 무엇인지
//그리고 어떻게 overload가 가능한지 확인

//int > decimal등으로 더 큰 데이터 타입으로 변환이 될 때 : implicit conversion이 일어남!
//하지만 큰 데이터 타입에서 작은 데이터 타입으로 변환이 될 때 : (대개 숫자형) explicit conversion이 일어남 : 그리고 일반적으로 변환을 그냥 하려고 하면 컴파일 에러가 뜸..
//반드시 그 앞에 (변환할 데이터 타입)을 붙여 주어야 함 > 일부 데이터 손실이 발생할 수 있음

//Hash function 이 무엇이고
//GetHashCode()함수와 어떤 연관이 있는지 확인
//좋은 hash function의 특징
//hash conflict 이 무엇인지? 그리고 왜 inevitable인가?

//GetHashCode : C# 오브젝트에 내장된 hash function 을 호출
//hash function : 암호화하는 알고리즘의 하나로 어느 형태의 입력 크기가 들어가도 나오는 것은 고정된 길이의 bits로 나옴

//hash code : hash function으로 어느 오브젝트의 필드의 값을 모두 hash function을 적용하여 얻은 결과
