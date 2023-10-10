namespace Fundamentals
{
    class ModifiedNames
    {
        public List<string> All { get; } = new List<string>();
        private readonly NameValidator _nameValidator = new NameValidator();

        public void AddNames(List<string> stringsFromFile)
        {
            foreach(var name in stringsFromFile)
            {
                AddName(name);
            }
        }

        public void AddName(string name)
        {
            //비교할 때마다 객체를 생성하는 것은 매우 좋지 않으므로..
            if (_nameValidator.IsValid(name))
            {
                All.Add(name);
            }
        }
        
    }
}