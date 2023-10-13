using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUnderHood
{

    class Main
    {
        void MainFunction()
        {
            //아래와 같이 파일 경로를 지정하면 프로그램이 실행되는 폴더 내부에 같이 파일이 생성
            string filePath = "file.txt";

            using(var writer = new WriteFile(filePath))
            {
                writer.Write("첫 번째 줄");
                writer.Write("두 번째 줄");
            }
            //위와 같이 처리하면 중간에 error가 발생하더라도 dispose가 실행되어 보다 안전하게 dispose를 확실하게 부를 수 있게 됨 :  try{}~finally{} 구문과 같은 역할을 수행함

            var reader = new FileReader(filePath);
            var third = reader.ReadLineNumber(3);
            var fourth = reader.ReadLineNumber(4);
            reader.Dispose();
            //위의 방식은 중간에 예외가 발생하면 아래의 Dispose가 발생하지 않을 수 있음!!
        }
    }
    /// <summary>
    /// 파일 쓰기!!! IDisposable 인터페이스를 통해 Dispose로 리소스를 해제해 보기!
    /// </summary>
    internal class WriteFile : IDisposable
    {
        private readonly StreamWriter _streamWriter;
        public WriteFile(string filePath)
        {
            _streamWriter = new StreamWriter(filePath, true);
        }

        

        public void Write(string text)
        {
            _streamWriter.WriteLine(text +Environment.NewLine);
            _streamWriter.Flush();
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }
    }
    internal class FileReader : IDisposable
    {
        private readonly StreamReader _streamReader;
        public FileReader(string filePath)
        {
            _streamReader = new StreamReader(filePath);
        }

        

        public string ReadLineNumber(int lineNumber)
        {
            
            _streamReader.DiscardBufferedData();
            _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for(var i  =0; i< lineNumber-1; i++)
            {
                _streamReader.ReadLine();
            }
            return _streamReader.ReadLine();
        }
        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
