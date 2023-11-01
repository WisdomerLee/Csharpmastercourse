//티켓 관련 프로그램 만들기!
//pdf에서 문자열 출력하기

using System.Globalization;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

class TicketsAggregator
{
    readonly string _ticketFolder;
    readonly Dictionary<string, CultureInfo> _domainToCultureMapping = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".fr"] = new CultureInfo("fr-FR"),
    };
    readonly IFileWriter _fileWriter;
    readonly IDocumentsReader _documentsReader;

    public TicketsAggregator(string ticketFolder, IFileWriter fileWriter, IDocumentsReader documentsReader)
    {
        _ticketFolder = ticketFolder;
        _fileWriter = fileWriter;
        _documentsReader = documentsReader;
    }
    //다른 플러그인의 클래스와 밀접하게 연결된 것은 좋지 않음...
    //

    public void Run()
    {
        var stringBuilder = new StringBuilder();

        var ticketDocuments = _documentsReader.Read(
            _ticketFolder);

        foreach (var document in ticketDocuments)
        {
            var lines = ProcessDocument(document);
            stringBuilder.AppendLine(string.Join(Environment.NewLine, lines));
        }

        //decimal widthInPoints = page.Width;
        //decimal heightInPoints = page.Height;



        _fileWriter.Write(stringBuilder.ToString(), _ticketFolder, "aggregatedTickets.txt");
    }


    //특정 영역을 함수로 리팩토링을 하고 싶다면??
    //함수로 만들고 싶은 부분을 드래그!
    //그리고 Alt+Enter를 누르면!
    //또한 함수를 추출할 때는 되도록 pure한 함수로 만드는 것이 좋음 : 이것은 입력된 값을 바꾸는 부분이 없는 경우!


    private IEnumerable<string> ProcessDocument(string document)
    {
        var split = document.Split(new[] { "Title:", "Date:", "Time:", "Visit us:" }, StringSplitOptions.None);

        var domain = split.Last().ExtractDomain();
        var ticketCulture = _domainToCultureMapping[domain];
        for (int i = 1; i < split.Length - 3; i += 3)
        {
            yield return BuildTicketData(split, i, ticketCulture);
        }
    }

    string BuildTicketData(string[] split, int i, CultureInfo ticketCulture)
    {
        var title = split[i];
        var dateAsString = split[i + 1];
        var timeAsString = split[i + 2];
        var date = DateOnly.Parse(dateAsString, ticketCulture);
        var time = TimeOnly.Parse(timeAsString, ticketCulture);
        //DateOnly, TimeOnly : .NET 6이상부터 쓸 수 있음

        var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
        var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);
        var ticketData = $"{title,-40}|{dateAsStringInvariant}|{timeAsStringInvariant}";
        return ticketData;
    }


}


public static class WebAddressExtensions
{
    public static string ExtractDomain(this string webAddress)
    {
        var lastDotIndex = webAddress.LastIndexOf('.');
        return webAddress.Substring(lastDotIndex);
    }
}

public interface IDocumentsReader
{
    IEnumerable<string> Read(string directory);
}

public class DocumentsFromPdfsReader : IDocumentsReader
{
    public IEnumerable<string> Read(string directory)
    {
        foreach (var filePath in Directory.GetFiles(directory, "*.pdf"))
        {
            using PdfDocument document = PdfDocument.Open(filePath);
            //int pageCount = document.NumberOfPages; 

            Page page = document.GetPage(1);
            yield return page.Text;
        }
    }
}
public interface IFileWriter
{
    void Write(string content, params string[] pathParts);
}
public class FileWriter : IFileWriter
{
    public void Write(string content, params string[] pathParts)
    {
        var resultPath = Path.Combine(pathParts);
        File.WriteAllText(resultPath, content);
        Console.WriteLine("Results saved to " + resultPath);
    }
}