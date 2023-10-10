namespace Fundamentals
{
    //다섯개의 책임을 다섯개의 클래스로 쪼개기!
    //이름을 확인하는 기능을 분리
    class NameValidator
    {
        public bool IsValid(string name)
        {
            return name.Length >= 2 && name.Length < 25 && char.IsUpper(name[0]) && name.All(char.IsLetter);
        }
    }
}