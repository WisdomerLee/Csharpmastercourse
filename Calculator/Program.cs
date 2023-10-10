// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, other Project in solutions");
Console.WriteLine("Input the first number:");
var firstAsText = Console.ReadLine();
var number1 = int.Parse(firstAsText);
Console.WriteLine("Input the second number:");
var secondAsText = Console.ReadLine();
var number2 = int.Parse(secondAsText);

Console.WriteLine("What do you want to do?");
Console.WriteLine("[A]dd numbers");
Console.WriteLine("[S]ubtract numbers");
Console.WriteLine("[M]ultiply numbers");

var choice = Console.ReadLine();

//loop : while() : ()내부의 값이 거짓이 될 때까지 {}로 묶인 내용이 계속 실행
//do-while : 무조건 한 번은 실행됨
//for : 몇 번 반복하는 것 지정하기 간편함
//break : break가 포함된 {}를 벗어남
//continue : 반복문에서 해당 조건을 만나면 건너뛰고 그 다음으로 실행

//2차원, 3차원, n차원 배열....
//n차원의 배열의 크기를 얻는 방법 : 배열.GetLength(index) : index : 얻고자 하는 차원의 숫자-1

//foreach : 
//리스트.AddRange(배열/리스트) : 해당 배열/리스트의 모든 목록이 원본 리스트에 추가
//리스트.IndexOf(찾는 원소) : 찾는 원소의 리스트 속의 순서 : 없으면 -1을 출력
//리스트.Contains(찾는 원소) : 해당 원소가 리스트에 있는지 확인
//리스트.Clear() : 리스트 모두 비우기
//out 키워드 : return과 별도로 추가로 함수에서 벗어나는 변수를 전달할 수 있는 방식
//함수 선언에서도 out을 선언하고 쓸 때도 out 키워드를 같이 써야 함
//TryParse : 숫자로 변환할 수 없는 형태면 false를 반환, 숫자로 변환할 수 있으면 true,  out으로 숫자를 얻을 수 있음
//Parse와 차이 : Parse: 숫자로 변환할 수 없으면 예외가 발생, TryParse : 예외가 발생하지 않음의 차이가 있음

//

string word = "";
System.Text.RegularExpressions.Regex regex = new(word);


switch (choice)
{
    case "S":
    case "s":
        var sum = number1 + number2;
        //Console.WriteLine(number1 + " + "+number2 + " = " + sum);
        PrintFinalEquation(number1, number2, sum, "+");
        break;
    case "A":
    case "a":
        var difference = number1 - number2;
        //Console.WriteLine(number1 + " - " + number2 + " = " + difference);
        PrintFinalEquation(number1, number2, difference, "-");
        break;
    case "M":
    case "m":
        var multiplied = number1 * number2;
        //Console.WriteLine(number1 + " x " + number2 + " = " + multiplied);
        PrintFinalEquation(number1, number2, multiplied, "x");
        break;
    default:
        Console.WriteLine("Invalid Input!");
        break;
}

if (EqualsCaseInsensitive(choice, "A"))//choice == "a"등과 같은 것을..?
{
    var sum = number1 + number2;
    //Console.WriteLine(number1 + " + "+number2 + " = " + sum);
    PrintFinalEquation(number1, number2, sum, "+");
}
else if(EqualsCaseInsensitive(choice, "S"))
{
    var difference = number1 - number2;
    //Console.WriteLine(number1 + " - " + number2 + " = " + difference);
    PrintFinalEquation(number1, number2, difference, "-");
}
else if (EqualsCaseInsensitive(choice, "M"))
{
    var multiplied = number1 * number2;
    //Console.WriteLine(number1 + " x " + number2 + " = " + multiplied);
    PrintFinalEquation(number1, number2, multiplied, "x");
}
else
{
    Console.WriteLine("Invalid Input!");
}

void PrintFinalEquation(int number1, int number2, int result, string @operator)
{
    Console.WriteLine($"{number1} {@operator} {number2} = {result}");
}

bool EqualsCaseInsensitive(string left, string right)
{
    return left.ToUpper() == right.ToUpper();
}
