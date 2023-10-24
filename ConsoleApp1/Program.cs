//Records, positional record 는 무엇??
//그리고 장점은??


var weatherData = new WeatherData(25, 65);
//아래와 같이 with를 통해 non-destructive mutation이 가능
var warmerWeatherData = weatherData with { Temperature = 30 };
Console.WriteLine(weatherData);



//아래와 같이 별도의 클래스(데이터 타입을 만들고...)
//출력을 하였을 때 온도, 습도를 출력하게 하고 싶으면 : ToString()함수를 override
//그것이 value들이 같으면 같은 형태로 만들고 싶고 : Equals()함수를 override, GetHashCode()도 override
//: 위와 같은 간단한 것을 만들기 위해 코드를 작성해야 할 것이 많음.....
//(40줄이 넘는 코드가 쓰임)


//class WeatherData : IEquatable<WeatherData?>
//{
//    public decimal Temperature { get; }
//    public int Humidity { get; }
//    public WeatherData(decimal temperature, int humidity)
//    {
//        Temperature = temperature;
//        Humidity = humidity;
//    }

//    public override string ToString() => $"Temperature: {Temperature}, Humidity : {Humidity}";

//    public override bool Equals(object? obj)
//    {
//        return Equals(obj as WeatherData);
//    }

//    public bool Equals(WeatherData? other)
//    {
//        return other is not null &&
//               Temperature == other.Temperature &&
//               Humidity == other.Humidity;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Temperature, Humidity);
//    }

//    public static bool operator ==(WeatherData? left, WeatherData? right)
//    {
//        return EqualityComparer<WeatherData>.Default.Equals(left, right);
//    }

//    public static bool operator !=(WeatherData? left, WeatherData? right)
//    {
//        return !(left == right);
//    }
//}

//record라는 것은 위의 상황을 간편히 만들기 위해 도입된 것!!
//아래의 한 줄이 위의 40줄이 넘는 코드와 같은 역할을 함... : positional record
//record 속에 들어간 것들은 Property이므로 대문자로 쓰는 것이 좋음
public record WeatherData(decimal Temperature, int Humidity);

//record : C#9.0부터 도입된 것
//reference type이나 equality, hash는 value를 기준으로 판별함
//상속이 허용됨
//record : 기본으로 Eqauls()함수를 override, Equals(T t)함수도 역시 내장, IEquatable<T> interface 자동 구현, GetHashCode override, ==, != 연산자도 override, ToString()함수도 override!!
//기본적으로 record는 body에 해당되는 부분이 없음... 선언만 하면 !!

//아래와 같이 읽기 전용인 속성 중 일부를 쓰기로 바꿀 수도 있음!!
//선언하지 않은 나머지 부분은 컴파일러가 알아서..
public record WeatherDataRegularRecord
{
    public decimal Temperature { get; set; }
    public int Humidity { get; }
    public WeatherDataRegularRecord(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }
    public void SomeMethod()
    {

    }
}

//record struct라는 데이터 타입도 있음
//둘 다 value type을 기준으로 같음을 처리할 수 있게 만들어진 것
//record struct : value type, mutable
//record : reference type, positional record : 기본적으로 immutable
//

//기본적으로 변경 가능하나
public record struct Rectangle(int A, int B);
//읽기 전용으로 만들 수도 있음
public readonly record struct RectangleRead(int Width, int Height);
//record, record struct : C# 9, C# 10에서 도입된 개념
//그리고 데이터의 형태를 간단히 나타낼 때 쓰임
