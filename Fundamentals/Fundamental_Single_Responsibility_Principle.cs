global using System;//같은 프로젝트에 속한 모든 클래스들은 해당 네임스페이스의 클래스를 바로 쓸 수 있음!

using System.Collections.Generic; //이렇게 두면 해당 클래스만 해당 네임스페이스에 접근!
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 네임스페이스를 자주 쓰는 경우라면...? 클래스 위쪽에 global로 using을 선언하여 해당 네임스페이스의 클래스들을 활용할 수 있음!

namespace Fundamentals
{
    /// <summary>
    /// SOLID의 기본 5가지 원칙 중에 하나!
    /// Single Responsibility Principle : 매우 중요한 요소 - 클래스는 오직 하나만 책임져야 함
    /// 클래스의 내용이 바뀌는 이유는 오직 하나여야 함!!
    /// 또한 DRY : 같은 내용을 반복하지 말 것 > 이것은 같은 일을 하는 함수를 여러 곳에 두지 말 것...!
    /// 그리고 파일 하나에 클래스는 하나씩만 있어야 함!!!
    /// </summary>
    internal class Fundamental_Single_Responsibility_Principle
    {
        //하나하나 작은 기능으로 쪼개는 것부터 시작하기
        //repository가 무엇인가?
        //새 줄을 나타내는 기호: Unix와 Unix시스템이 아닌 경우
        // 클래스에서의 메서드 순서??
    }

    //SOLID 원칙이 파괴된 클래스...
    class Names
    {
        private List<string> _names = new List<string>();

        public void AddName(string name)
        {
            if (IsValidName(name))
            {
                _names.Add(name);
            }
        }
        private bool IsValidName(string name)
        {
            return name.Length >= 2 && name.Length < 25 && char.IsUpper(name[0]) && name.All(char.IsLetter);
        }
        public void ReadFromTextFile()
        {
            var fileContents = File.ReadAllText(BuildFilePath());
            var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
            foreach (var name in namesFromFile)
            {
                AddName(name);
            }
        }

        public void WriteToTextFile()
        {
            File.WriteAllText(BuildFilePath(), Format());
        }

        public string BuildFilePath()
        {
            return "name.txt";
        }

        public string Format()
        {
            return string.Join(Environment.NewLine, _names);
        }
    }

    //같은 네임스페이스로 묶인 클래스는 서로를 호출 할 수 있음!

}