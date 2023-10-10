
var random = new Random();

var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

Console.ReadKey();

Season firstSeason = Season.Spring;


//조건이 오직 둘 뿐이고(참, 거짓)이고 그에 따라 들어가는 값이 달라질 경우 (조건) ? 참일 경우의 값 : 거짓일 경우의 값을 쓸 수 있음
enum Season
{
    Spring, Summer,Autumn, Winter
}

class GuessingGame
{
    private readonly Dice _dice;
    private const int initialtries = 3;
    private ConsoleReader _ConsoleReader = new ConsoleReader();
    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public bool Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"주사위를 굴렸습니다. {initialtries}번 안에 어느 숫자가 나왔는지 찍어봅시다");

        var triesLeft = initialtries;
        while(triesLeft > 0)
        {
            var guess = _ConsoleReader.ReadInteger("숫자를 입력하세요!");
            if(guess == diceRollResult)
            {
                return true;
            }
            Console.WriteLine("잘못된 숫자입니다");
            --triesLeft;
            
        }
        return false;
    }
    
}

class ConsoleReader
{
    public int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}

class Dice
{
    private readonly Random _random;
    private readonly int sideCount;
    public Dice(Random random, int sideCount = 6)
    {
        _random = random;
        this.sideCount = sideCount;
    }
    public int Roll() => _random.Next(1, sideCount + 1);
    public void Describe() => Console.WriteLine($"{sideCount}면 주사위");
}
