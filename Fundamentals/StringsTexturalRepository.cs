namespace Fundamentals
{
    //파일을 담당하는 기능을 분리 - Repository :파일 접근, 제어를 담당하는 부분
    class StringsTexturalRepository
    {
        //unix system : linux, macOS -> "\n"
        //non-unix system: windows -> "\r\n"
        private readonly string seperator = Environment.NewLine;
        public List<string> Read(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(seperator).ToList();
        }

        public void Write(string filePath, List<string> textToBeSaved)
        {
            File.WriteAllText(filePath, string.Join(Environment.NewLine, textToBeSaved));
        }
    }
}