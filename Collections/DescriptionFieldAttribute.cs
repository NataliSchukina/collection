namespace Collections

{
    public class DescriptionFieldAttribute : System.Attribute
    {
        public DescriptionFieldAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

