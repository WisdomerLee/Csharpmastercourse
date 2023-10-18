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

    //GetHashCode도 override > Equals를 override하면 이것도 override할 것!
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
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
//같은 오브젝트라면 hashcode가 같음 > 즉 hashcode 가 같으면 같은 오브젝트
//hashset collections
//Dictionary 데이터의 경우 대표적인 예시
//key로 들고 있는 것들이 아주 단순한 데이터부터 클래스들에 이르기까지 다양하게 쓰일 수 있는데 처음 키, 값을 지정할 때 
//키로 들어온 오브젝트의 hashcode를 계산함
//매우 복잡한 오브젝트를 숫자 형태로 변환() > 이유는 ?? 단순한 숫자로 처리하면 검색 등에서 매우 빠름
//아주 드물게도 다른 오브젝트인데도 hash code의 값이 같은 경우가 발생할 수도 있음 : hash code conflict
//원칙적으로는 서로 다른 오브젝트는 hash code 값이 달라야 하지만 드물게도 (경우의 수 자체가 매우 많긴 하지만 드문 확률로 중복이 발생할 수도 있음) 겹칠 수도 있음
//매우 많은 오브젝트를 갖고 있으면 그 중엔 같은 hash code를 갖는 것들이 섞여있을 수도 있음

//GetHashCode : C# 내부적으로 가진 기본 함수로는 value type, reference type별로 다르게 계산되는데
//reference type은 reference 자체를 계산하게 되고
//value type은 해당 value들을 모아 계산하게 됨

//GetHashCode 메소드를 override해야 할 경우
//Equals메서드를 override한 경우 : 같은 오브젝트는 hash code도 같아야 함!
//hashed collection에 키로 쓰일 타입을 쓸 경우
//struct의 경우 기본의 경우 conflict 리스크가 있고, 느리므로 override하는 것이 좋음

//GetHashCode 메소드를 덮어씌우기
//HashCode.Combine 함수 확인하기

//기본적으로 GetHashCode는 integer를 반환하는 함수이므로 오브젝트마다 다른 int 값을 가진 것을 돌려주게 하면 됨!
