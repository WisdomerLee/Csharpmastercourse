using System.Text.Json;


var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine("이 어플리케이션은 개발중에 있어 의도치 않은 에러가 발생할 수 있습니다. ");
    logger.Log(ex);
}

Console.ReadKey();


public class GameDataParserApp
{
    public void Run()
    {

        bool isFileRead = false;
        var fileContents = default(string);
        var fileName = default(string);
        do
        {
            try
            {
                Console.WriteLine("읽고 싶은 파일의 이름을 입력하기!");
                fileName = Console.ReadLine();
                fileContents = File.ReadAllText(fileName);
                isFileRead = true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("파일 이름은 빈 칸이 될 수 없습니다");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("잘못된 파일 이름");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("해당 파일이 없음!");
            }
        }
        while (!isFileRead);

        List<VideoGame> videoGames = default;
        try
        {
            videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException ex)
        {
            throw new JsonException($"{ex.Message} 파일 이름: {fileName}", ex);
        }


        if (videoGames.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Loaded games are");
            foreach (var videogame in videoGames)
            {
                Console.WriteLine(videogame);
            }
        }
        else
        {
            Console.WriteLine("input file");
        }
    }
}


//Json convert to C# classes online을 구글로 검색하여 사이트에 들어가 json에 있는 형태 하나를 그대로 복사하여 집어넣으면 아래와 같이 변환을 시켜줌!!
public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }
    public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";
}