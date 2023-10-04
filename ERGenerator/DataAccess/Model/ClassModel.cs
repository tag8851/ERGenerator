namespace ERGenerator.DataAccess.Model
{
    public class ClassModel
    {
        public class PropertyModel
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Comment { get; set; }
        }
        public string NameSpace { get; set; }
        public string Name { get; set; }
        public string BaseClass { get; set; }
        public List<PropertyModel> Properties = new List<PropertyModel>();
    }
}
