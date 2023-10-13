using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUnderHood
{
    //CSV파일이 뭔가??
    //그리고 이 파일로 작업하면 무엇이 좋은가??
    //CSV = comma-separated values
    //excel로 열 수도 있는데 이 파일들은 값들이 콤마로 분리되어 있음
    //행렬로 되어있는 값들 : 각 줄은 하나의 오브젝트를, 각 콤마로 분리된 값은 필드 값을 가리킴!
    //spreadsheet 형태로 되어있는 데이터 형태 : 기술적인 배경 없이 데이터를 쉽게 이해할 수 있음
    //excel로 쉽게 열 수 있음, 그 외의 발전 단계에서의 선택 등으로..
    //CSV 형태로 된 파일을 읽을 수 있는 클래스를 어떻게 만드는가?
    //그리고 StreamReader를 실제로 어떻게 쓰는지
    //또한 \가 특수 캐릭터로 어떻게 다른 특수 문자들이 있는 상황에서 구분할 수 있는지 등등
    //이미 CSV를 불러와서 상호작용 할 수 있는 패키지들이 많이 있으나 연습 차원에서 직접 만들어 봄

    //Dictionary의 크기 줄이는 비법!
    //빈 오브젝트를 채우는 것보다 없으면 null을 ...

    //boxing operation을 줄이는 방법!
    //입력 데이터를 특정 타입으로 한정지었을 때 속도가 빨라지는가?
    //입력되는 데이터 타입을 이미 알고 있다면?!
    //메모리 관리 툴이 있음!
    //ANTS Memory Profiler
    //dotMemory


    //그런데 대개 csv로 저장된 파일들은 그 양이 매우매우 많다... > 그럼 다 읽어들이느라 컴퓨터가 뻗을 수 있음! 
    class CSVReader
    {
        //그런데 돌려주는 타입이 무엇이 될까?
        public CSVData Read(string filePath)
        {
            using(var streamReader = new StreamReader(filePath))
            {
                const string seperator = ",";
                var columns = streamReader.ReadLine().Split(seperator);

                var rows = new List<string[]>();
                while (!streamReader.EndOfStream)
                {
                    var cellsInRow = streamReader.ReadLine().Split(seperator);
                    rows.Add(cellsInRow);
                }
                return new CSVData(columns, rows);
            }
        }
    }
    //CSV의 데이터 형태!
    class CSVData
    {
        public string[] Columns { get; }
        public IEnumerable<string[]> Rows { get; }

        public CSVData(string[] columns, IEnumerable<string[]> rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }

    internal class WorkWithCSV
    {
        string path = @"C:\Users\...\sampleData.csv";

    }
}
