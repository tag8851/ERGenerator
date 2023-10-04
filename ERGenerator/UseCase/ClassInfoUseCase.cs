using ERGenerator.BissinessEntitiies;
using ERGenerator.DataAccess.Repositories;
using System.Data;

namespace ERGenerator.UseCase
{
    public interface IClassInfoUseCase
    {
        IEnumerable<ClassInfo> ReadClass(string path);
    }
    public class ClassInfoUseCase : IClassInfoUseCase
    {
        private readonly IRoslynParser _parser;
        public ClassInfoUseCase(IRoslynParser parser)
        {
            _parser = parser;
        }
        public IEnumerable<ClassInfo> ReadClass(string path)
        {
            var results = new List<ClassInfo>();

            foreach (var file in Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories))
            {
                var models = _parser.GetClassModel(file);

                if(models != null) 
                {
                    foreach (var model in models)
                    {
                        results.Add(new ClassInfo
                        {
                            Name = model.Name,
                            NameSpace = model.NameSpace,
                            BaseClassName = model.BaseClass,
                            Properties = model.Properties.Select(x => new Property
                            {
                                Name = x.Name,
                                Type = x.Type,
                                Comment = x.Comment,
                            }).ToList()
                        });
                    }
                }
            }

            foreach(var c in results)
            {
                c.BaseClass = results.Where(x => x.Name == c.BaseClassName).FirstOrDefault();
            }

            return results;
        }
    }
}
