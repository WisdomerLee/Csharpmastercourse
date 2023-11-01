//티켓 관련 프로그램 만들기!
//pdf에서 문자열 출력하기

const string TicketsFolder = @"C:\OurCinema\Tickets";

try
{
    var ticketsAggregator = new TicketsAggregator(
        TicketsFolder,
        new FileWriter(),
        new DocumentsFromPdfsReader()
        );
    ticketsAggregator.Run();
}
catch(Exception ex)
{
    Console.WriteLine($"예외 발생. {ex.Message}");
}

//클래스의 identity를 하나의 책임으로 만드는 법
//그리고 class를 Single Responsibility Principle에 맞게 만드는 법!
