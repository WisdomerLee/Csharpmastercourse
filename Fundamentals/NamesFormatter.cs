namespace Fundamentals
{
    class NamesFormatter
    {
        public string Format(List<string> All)
        {
            return string.Join(Environment.NewLine, All);
        }
    }
}