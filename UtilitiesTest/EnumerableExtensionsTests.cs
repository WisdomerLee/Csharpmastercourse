using ListImprovePerformance;
using Moq;
using NUnit.Framework;
using Utilities;
namespace UtilitiesTest;

//Unit Test??
//어떻게 테스팅 환경을 구성하는가?
//NUnit과 Moq library를 이용하여 테스트 만들기
//unit test 동작 원리와 필요한 이유
//unit test의 장점, 단점
//소프트웨어 테스트의 다른 경우들
//mock이 무엇이고 어떻게 쓰는가?
//unit test에서 코드를 깔끔하게 쓰는 법
//Code testability

//Manual test vs Automated test
//
//software testing : 코드가 개발자가 원하는대로 제대로 동작하는지를 살펴보는 것
//automated test : 사람이 직접 테스트하는 것에 비해 빠름
//실행하는데 큰 비용이 들지 않음...
//test를 실행하는데 위험성이 없음....
//바뀌는 것에 대해 저항이 사라짐...?

//test project 만들기
//unit test를 실행하기 위해 필요한 NuGet 패키지
//unit test 정의

//unit test  자동화된 테스트 기법으로 프로그램이 동작할 때 하나의 유닛을 테스트 함
//하나의 유닛(unit)은 프로그램의 로직과 분리된 가장 작은 단위...  대체로 클래스에서 하나의 메소드

//클래스 라이브러리로 독립된 프로젝트로 생성할 것!!!
//
//Unit test에서 NUnit이라는 것을 쓸 것 : C# 어플리케이션에서 가장 널리 쓰이는 unit test용 library

//NuGet Package에서 NUnit을 검색하여 NUnit(테스트 정의)과 NUnit3TestAdapter(테스트 실행)를 설치
//test sdk를 검색하여 Microsoft.NET.Test.Sdk를 설치할 것

//Unit test는 어떻게 쓰는지, 그리고 assertion이 무엇인가?를 살펴봄

//Unit test는 클래스 당 하나씩 붙어서 처리됨.. : 어느 클래스를 테스트 하는지를 확실히 알기 위해 같은 클래스 이름 뒤에 Test를 붙여 어느 기능을 테스트 하는지 명확히 할 것


//만약 클래스가 [Test] Attribute를 가진 함수를 1개 이상 포함하면 컴파일러 단계에서 자동으로 해당 클래스가 test fixture Attribute를 가짐을 바로 파악함..
//테스트할 클래스가 있는 프로젝트를 참조에 추가할 것...
[TestFixture]
public class EnumerableExtensionsTests
{
    //[Test] : Unit Test에서 매우 중요한 Attribute
    //위의 Attribute가 없으면 Test 함수로 인식하지 않음..
    //그래서 test가 성공, 실패했는지를 판별할 수 없음...
    //
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollection()
    {
        var input = Enumerable.Empty<int>();

        var result = input.SumOfEvenNumbers();

        //Assertion : 해당 기능이 제대로 동작하는지 확인하는 것
        Assert.AreEqual(0, result);
        //앞에 있는 것이 예상되는 결과, 뒤의 것이 코드를 통해 나온 결과!
        //해당 순서는 반드시 제대로 지킬 것!!
        //unit test 실행하고 debug하는 방법
        //[Test] 우클릭 : 테스트 실행을 눌러볼 것
        //
        //Test explorer는 테스트를 실행하면 자동으로 뜨는데
        //테스트 탐색기에서 함수 이름을 더블클릭하면 해당 클래스 함수로 화면을 이동시킴
        //
        //또한 Test가 실패할 경우
        //어디서 실패했는지 찾기 어려울 수 있음
        //Test를 Debug로 실행하여 확인해보기.. : 중단점을 찍어서...(물론 테스트 성공 시에는 중단점이 동작하지 않음) : 테스트 실패시에 중단점이 적용됨..

        //unit test의 이름 짓기
        //함수 이름, 예측된 결과, 시나리오
        //위의 3가지를 _로 묶어서 테스트 함수 이름으로...

        //테스트 메시지 
        //테스트 실패시 그 이유를 설명하는 것이 테스트 메시지
        //
    }
    //AAA 패턴이 무엇인지 확인하기
    //Arrange, Act, Assert
    //테스트가 반드시 갖춰야 할 3가지 요소
    //Arrange : 테스트가 실행되기 위해 필요한 조건, 오브젝트 등의 설정 갖추기
    //Act : 테스트를 할 함수 실행
    //Assert : 실행된 함수 값 확인, 
    [Test]

    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbersArePresent()
    {
        var input = new int[] { 3, 1, 4, 6, 7 };

        var result = input.SumOfEvenNumbers();

        var expected = 10;
        var inputAsString = string.Join(", ", input);
        //Assertion : 해당 기능이 제대로 동작하는지 확인하는 것, 그리고 Assert에 비교하는 값들 다 넣고 난 뒤에 넣는 메시지는 테스트 실패 시 출력할 메시지가 됨
        Assert.AreEqual(10, result, $"For input {inputAsString} the result shall be {expected} but it was {result}");
    }

    //test case!! testcase로 묶은 것들 ()안의 것들은 바로 아래의 함수의 파라미터로 들어감!!
    //여기서는 하나의 int 값들로 구성되었으므로 파라미터가 int가 됨...

    [TestCase(8)]
    [TestCase(6)]
    [TestCase(10)]
    [TestCase(-12)]
    [TestCase(0)]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfOnlyNumberInInputIsEven(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(number, result);
    }
    [TestCase(7)]
    [TestCase(3)]
    [TestCase(-5)]
    [TestCase(-11)]
    [TestCase(1)]
    public void SumOfEvenNumbers_ShallReturnZero_IfOnlyNumberInInputIsOdd(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(0, result);
    }

    
    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumberExistsInInput(IEnumerable<int> input, int expected)
    {
        
        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(expected, result);
    }

    private static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] {new int[] {3,1,4,5,7}, 4 },
            new object[] {new List<int> {100,200,7}, 300 },
            new object[] {new List<int> {-3,-5,0}, 0 },
            new object[] {new List<int> {-4,-8,7}, -12 },
        };
    }

    //test case의 이름 지정하기!!!
    //만약 null을 허용하지 않는 곳에  null을 테스트로 집어넣게 된다면??

    [Test]
    public void SumOfEvenNumbers_ShallThrowException_ForNullInput()
    {
        IEnumerable<int>? input = null;
        //Assert.Throws<NullReferenceException>(() => input!.SumOfEvenNumbers());
        Assert.Throws<ArgumentNullException>(() => input!.SumOfEvenNumbers());
        //Assert.AreEqual("abc", exception.Message);
        //위와 같이 exception의 메시지를 비교하는 방식은 좋은 접근 방법이 아님!
        //또한 하나의 테스트에는 하나의 Assert만 있어야 함!
        //그리고 Assert가 꼭 연계되어야 한다면... > ... 쓸 수도 있으나 추천하지 않음!
    }
    //unit test의 가치
    //code coverage??


    //코드 리팩토링의 실패 등의 것등을 unit test를 실행시켜 간단히 확인할 수 있음!
    //test coverage : code가 unit test로 얼마나 커버되는지...

    //대부분의 프로젝트는 시간이 지남에 딸 품질이 낮아짐 (새로운 요구사항들의 반영 등으로)
    //refactoring으로 품질을 올릴 수 있음!

    //assertion들 종류
    [Test]
    public void TestAssertion()
    {
        IEnumerable<int>? input = null;
        //앞이 개발자가 의도한 결과, 뒤는 실제 코드로 나온 결과를 넣고 비교
        //Assert.Equals(0, 0);
        //Equals : 값이 같은지 비교할 때 쓰임 > 하지만 이것보단... AreEqual()로 쓰는 것이 더 낫다고 함..
        //
        //Assert.Throws<ArgumentNullException>(() => input!.SumOfEvenNumbers());
        //Assert.Throws<> : ()안에 들어간 함수 식이 진행될 때 <>에 들어간 예외를 발생시켜야 함!
        Assert.DoesNotThrow(() => input!.SumOfEvenNumbers());
        //Assert.DoesNotThrow() : ()안에 들어간 함수 식이 진행될 때 예외가 발생하면 안 됨!

        //
    }
    [Test]
    public void TestAssertion2()
    {
        bool someVariable = true;
        //Assert.True(someVariable);
        //Assert.False(someVariable);
        //Assert.True() : ()안의 값이 True일 때 테스트 통과
        //Assert.False() : ()안의 값이 False일 때 테스트 통과
        Assert.Null(someVariable);
        //Assert.Null() : ()안의 값이 null일 때 테스트 통과
        Assert.NotNull(someVariable);
        //Assert.NotNull() : ()안의 값이 null이 아닐 때 테스트 통과
        //
    }
    //public으로 선언된 함수들은 [Test]로 묶이는 함수 밑에서 호출하기가 매우 편리함. 해당 클래스의 객체를 만들고 그 함수를 바로 호출하여 확인하는 식이면 되기 때문...
    //그런데.. private으로 선언된 함수들을 [Test]로 확인해야 한다면 어떻게 해야 할까?
    //public으로 선언된 interface들을 테스트 하는 용도로 unit test를 진행함
    //그럼 private으로 선언된 함수의 변화를 테스트 한다면...?
    //private에 직접 접근하는 형태로 Test를 진행하는 것이 아니라
    //private의 함수를 바꾸어가며 public 으로 선언된 함수의 값들이 Test를 통과하는지를 추적해 가면 됨...

    //internal 함수는 그럼 어떻게...?
    //test할 assembly의 클래스 중 하나의 파일 최상단에 (namespace위에) 선언을 하나 함
    //[assembly:InternalsVisibleTo("UtilitiesTest")] //이 조건은 internal로 선언된 것을 해당 프로젝트에서 보일 수 있도록 선언하는 것... : 또한 이 선언은 namespace보다도 더 위에 있어야 함..
    //또한 위의 선언은 직접적으로 ""으로 넣어야 함 nameof()를 쓸 수 없음 > 그럼 저 것은 왜 쓰는가? > Unit Test를 할 때 internal로 선언된 클래스들의 함수들을 확인할 때 씀..
    //어느 프로젝트에서 접근 가능하게 함을 이름으로 넣어야 하므로 만약 unit test의 프로젝트의 이름이 바뀌면
    //저 위에 선언한 곳의 이름도 직접 바꾸어야 함..
    //
    //unit test가 refactoring과 코드 품질 향상을 어떻게 가능하게 하는지와
    //소프트웨어 생산에 어느 영향을 미치는지...

    //unit test 코드는 함수 자체의 코드보다도 더 긴 경우가 많음...
    //또한 함수의 내용이 바뀌게 되면 unit test의 코드도 바꾸어야 함...
    //시간이 소요되는 일...
    //또한 대부분의 경우에는 주요 코드에는 unit test 코드를 만들도록 요청하는 경우가 많음!

    //unit test의 장점은
    //코드가 개발자의 의도대로 제대로 작성되고 동작한다는 확신을 줌
    //또한 unit test는 코드 자체적으로 실행하기 때문에 일일이 확인하는 것보다 더 나음...
    //unit test로 실행할 경우 refactoring을 할 때 unit test를 통해 refactoring된 코드도 원하는대로 동작하는지 바로 확인할 수 있음!
    //
    //refactoring이 없으면... 코드 품질이 시간에 따라 점차 떨어짐..
    //그리고 새 기능을 추가하는 것이 점차 어려워짐
    //

    //unit test의 장점 : 코드의 디자인이 더 좋아짐

    //TDD??

    //unit test 코드를 작성하다보면 코드 디자인이 나쁜 상황을 금방 눈치챔
    //코드 디자인이 나쁜 상태라면 unit test를 추가할 때 더 더하기 어렵다는 것을 금방 확인할 수 있음
    //unit test를 추가하기 어려운 상태 : 코드 디자인이 좋지 않은 상태
    //class를 나누거나 dependency injection의 경우 등도 확인할 수 있음
    //unit test를 하기 쉬운 상태 : 코드 디자인이 좋은 상태
    //Test Driven Development : unit test를 만들고
    //코드를 넣을 땐 테스트 코드가 통과했을 때만..
    //코드 품질을 유지하기 좋은 방법
    //코드의 버그를 일찍 찾음!! 작성에 시간이 걸리긴 하지만 이미 작성되고 나면...

    //unit test는 각각의 기능에 대한 부분을 동작 확인 함
    //system 전체에서 묶일 때 발생하는 문제들은 확인할 수 없음!
    //잘못 디자인된 개발상품의 경우 개발 시간, 유지 시간이 오래 걸림
    //
    //unit test : white-box test
    //프로그램의 상세한 부분을 모두 알고 있어야 함
    //Black-box test : 상세한 부분을 모름..

    //unit test를 하지 않는 경우 : 프로그램 자체가 크지 않은 경우
    //POC를 진행할 경우
    //

    //dependency injection의 경우 dependency injection이 처리되었는지 확인할 경우...
    //unit test 코드를 작성할 때는
    //로직은 신경쓰지 말고 그 결과가 어떻게 나오는지만 이해하면 됨..
    //
    //그런데... 만약 데이터 베이스에서 데이터를 들고 와서 그 값을 제대로 들고 오는지를 확인해야 하는 함수를 테스트를 할 때는...?
    //그럼 해당 데이터 베이스와 연동된 환경을 모두 깔고 테스트를 진행해야 하는가??

    //그리고 데이터 베이스의 내용을 지우거나 하는 내용들을 테스트 할 때는??
    //unit test는 서로 독립적이어야 하고 하나의 테스트가 다른 테스트에 영향을 주어서도 안 된다...
    //또한 data base에 직접 접근하여 처리할 경우...
    //직접 데이터 베이스에 접근해서 테스트를 할 경우... 느림..
    //mock이라는 것을 도입하여 해결할 수 있음!!

    //mock이 무엇이고 어떻게 쓰는가?
    //Moq 라이브러리

    //mock : 다른 오브젝트에서 확장된 것
    //mocked된 오브젝트와 같은 interface를 가지고 있음!
    //mocked된 오브젝트는 Setup이라는 함수로 해당 interface를 실행하고
    //그 외의 다른 함수들로 ...
    //
    //mock의 Setup에 쓰일 것...
    //Mock으로는 interface를 사용하는 임의의 객체를 만들어주는데, interface에 속해있는 함수들을 호출할 수 있게 처리해줌...
    //또한 Setup이라는 함수를 통해 mock에 해당하는 객체의 설정을 바꾸어줄 수 있음!!
    //또 Reset이라는 함수를 통해 mock의 설정을 초기화 할 수 있음!
    //(다양한 여러 값들을 테스트 해야 할 경우에 Reset, Setup을 처리한 뒤에 함수를 호출하여 처리할 수 있음!
    //It.IsAny<T>() <<< 이 값은 T에 해당되는 데이터 타입에 해당되는 어느 값이든 처리할 수 있음을 뜻함!!
    //It.Is<T>(Func<T, bool>) 함수는? : Func로 람다 함수를 넣을 수도 있는데
    //T를 받는 데이터 타입 중에 bool이 참이 되는 조건에 해당되는 애들만 받아 처리함!
    //SetupSequence() : 돌려주어야 할 값들을 여럿 설정하여 첫번째, 두번째, 세번째 호출할 때의 값을 다르게 설정할 수 있음!!
    //또한 Throws() : Setup의 입력을 받았을 때 예외를 발생시켜야 할 때!!
    //Setup은 되도록 단순하게 처리해야 함!
    
    //함수가 호출된 것을 Assert로 확인하고 싶을 때
    //예를 들어 void 함수라면 

    [Test]
    public void TestWithMock()
    {
        //mock : fake object
        var databaseConnectionwork = new Mock<ICollection<int>>();
        //databaseConnectionwork.Object
        databaseConnectionwork.Setup(mock => mock.Add(5));
        //Verify : 전달된 함수의 조건이 맞게 설정되었는지 확인하는데 씀!: 해당 함수가 호출되어 제대로 적용되었는지 확인 : void 함수가 호출되었는지 확인할 때 씀..
        //또한 Verify에 들어간 Times.Once()등을 설정하면 해당 함수가 한 번 혹은 여러번 호출되었는지 확인할 수 있음!!!
        
        databaseConnectionwork.Verify(mock => mock.Contains(5), Times.Once());
        //Times.Once(), Times.Never(), Times.Exactly(숫자), Times.AtLeast(숫자), Times.AtMost(숫자), Times.Between(숫자1, 숫자2)
        //Verify 함수 내부에 들어갈 조건에 It.IsAny<T>()를 집어넣을 수도 있음... : 해당되는 데이터 타입에 맞는 오브젝트라면 통과하도록!
        //
    }
    //unit test에서의 clean code
    //
    //여러 테스트에서 공용으로 쓸 common setup정의하기
    //_cut 오브젝트??
    //nullable reference type 이 test에 미치는 영향

    //공용으로 쓸 common setup을 TestFixture에 해당되는 클래스 내부에 필드로 선언하여 쓰면 되는 것일까??
    //>> 그렇지 않음... 다른 테스트에서도 쓰일 수 있는데 그럼 해당 필드를 변경하는 함수 들이 호출될 수도 있는데 그 경우 하나의 테스트가 다른 테스트들에 영향을 줄 수 있게 됨...
    //
    //
    [SetUp]
    public void Setup()
    {
        //여기에 공통으로 쓸 common setup을 선언할 것!! : 특정 클래스 혹은 Mock을 만든다거나 등의 내용을
        //그러면 테스트가 실행되기 전의 Setup에서 여기에 쓰인 함수 내용도 같이 호출됨!!
        //테스트 실행 직전에 호출!!
        //그럼 모든 테스트 별로 독립적으로 실행 : 코드 중복 방지
        //_cut : class under test 필드!!!
        //또한 test에 쓰일 것들은 test 직전에 호출되므로 컴파일러 입장에서는 cut으로 쓰이는 필드가 초기화가 되지 않은 상태임을 인지하여 경고를 띄움!!
        //하지만 실제로는...? > 테스트 직전에 호출되어 새 객체를 만들어주므로 null로 들어갈 일이 없음!
        //
    }
    //dependency inversion, dependency
    //dependency inversion : SOLID 원리 중에 하나 : 클래스는 오직 추상적인 부분에만 의존해야 함, 직접적인 의존은 지양...
    //dependency injection : constructor에서 class에 의존하는 객체들을 집어넣는 것 : 그래서 실제 집어넣을 때는...?
    //dependency inversion + dependency injection이 같이 적용되면 > constructor에 의존하는 Interface의 객체를 지정하도록 설정!!
    //이렇게 되면 concrete class타입을 변경할 때 아무 문제 없이 처리할 수 있음!!

    //dependency inversion principle을 어긴 경우!!?
    //static으로 선언된 클래스 중 테스트가 불가능한 경우
    //또한 test에서는 Randomness가 허용될 수 없음!!
    //static의 클래스의 경우 sealed되어있으므로 !!(자동으로)
    //
    //mock으로 선언될 필요가 없는 클래스
    //다른 클래스로 대체될 이유가 없는 클래스 등은 static으로 사용해도 문제 없음
    //

    //unit test와 다른 테스트 들
    //integration test
    // module들 간의 상호 작용이 필요할 경우 ??  전달이 제대로 되지 않는 경우 등을 확인하기 위해 ...

    //End-to-end test : 많은 어플리케이션의 경우 end-to-end 테스트를 실행함 : 주된 기능 점검!
    //selenium(web app)이 대표적인 예시

    //smoke test : 주요 기능을 점검하는 테스트
    //regression test : 코드 변화가 기존 기능에 영향이 없는지 확인하는 테스트
    // major refactoring이 일어날 경우 regression test 실행함

    //코드로 생성되는 메시지가 그것이 맞는지 확인하는 법??
    //
    //resource 파일, define 지정, 읽어오는 방법
    //
    //프로젝트를 우클릭하여 추가를 누른 뒤에 !
    //Resources File이라는 것을 확인할 수 있음 확장자 .resx
    //해당 파일은 C# 파일은 아니고 key-value 짝으로 이루어진 데이터임!
    //comment 부분은 파일 설명 부분인데 해당 부분은 프로그램, C#쪽에서 접근하지 않는 곳!
    //해당 파일은 xml 파일임...
    //그리고 해당 파일과 같은 이름으로 그 파일에 설정한 값들을 불러올 수 있음!
    //또한 파일은 기본적으로 internal임!
    //Access modifier를 public으로 선언해야 test 등에서 접근 가능함!
    //또한 resources file에서 있는 것을 string format으로 넣어 중간에 집어넣을 수 있음 {0}, {1} 등으로 ...
    //string.Format(Resource.Dice,. InitialTries);와 같은 형태로 넣어줄 수 있음!
    //

}





[TestFixture]
public class CalculatorTest
{
    
    [TestCase(1,2,3)]
    [TestCase(1,-1,0)]
    [TestCase(0,0,0)]
    [TestCase(100,-50,50)]

    public void Sum_ShallAddNumbersCorrectly(int a, int b, int expected)
    {
        var result = Calculator.Add(a, b);
        Assert.AreEqual(expected, result);
    }
    //test case의 한계
    //TestCaseSource attribute를 이용하여 파라미터 넘겨주기
    //만약 IEnumerable<int>를 받아서 넘겨주어야 할 경우
    //Testcase로 넘겨주게 되면??
    //array, list의 경우를 테스트 할 경우 test case로 넣어줄 수 없음...
    //이럴 때 쓰는 방법이 ...
}