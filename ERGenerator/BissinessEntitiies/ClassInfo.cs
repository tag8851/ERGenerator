namespace ERGenerator.BissinessEntitiies
{
    interface IClassInfo
    {
        IEnumerable<Property> GetProperties(bool all);
    }
    public class ClassInfo : IClassInfo
    {
        public string NameSpace { get; set; }
        public string Name { get; set; }
        public string BaseClassName { get; set; }
        public ClassInfo BaseClass { get; set; }
        public List<Property> Properties { get; set; }
        public IEnumerable<Property> GetProperties(bool all)
        {
            foreach (Property property in Properties)
            {
                yield return property;
            }
            if(BaseClass == null)
            {
                yield break;
            }
            if (all)
            {
                foreach (Property property in BaseClass.GetProperties(all))
                {
                    yield return property;
                }
            }
        }
    }
    public class Property
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
    }
}
