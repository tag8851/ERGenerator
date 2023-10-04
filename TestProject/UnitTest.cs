using CommunityToolkit.Mvvm.DependencyInjection;
using ERGenerator.Application;
using ERGenerator.BissinessEntitiies;
using ERGenerator.DataAccess.Repositories;
using ERGenerator.UseCase;

namespace TestProject
{
    public class UnitTest : IClassFixture<DIFixture>
    {
        [Fact]
        public void ERserviceTest()
        {
            var target = Ioc.Default.GetRequiredService<IERService>();

            var templateFilePath = "Samples\\Sample.tmpl"; 
            var projectPath = "Samples";
            var outputFilePath = "outputER.txt";

            target.MakeER(templateFilePath, projectPath, outputFilePath);
        }
        [Fact]
        public void RoslynTest()
        {
            var target = Ioc.Default.GetRequiredService<IRoslynParser>();

            var obj = target.GetClassModel("Samples\\Emp.cs");
            Assert.Equal("TestProject.Samples", obj[0].NameSpace);
            Assert.Equal("Emp", obj[0].Name);
            Assert.Equal("EntityBase", obj[0].BaseClass);
        }
        [Fact]
        public void ClassInfoUseCaseTest()
        {
            var target = Ioc.Default.GetRequiredService<IClassInfoUseCase>();

            var clasInfos = target.ReadClass("Samples").ToList();

            Assert.Equal(3, clasInfos.Count);
        }
        [Fact]
        public void ClassInfoTest()
        {
            var baseClassInfo = new ClassInfo
            {
                Name = "BaseClass",
                BaseClassName = null,
                BaseClass = null,
                Properties = new List<Property>
                {
                    new Property
                    {
                        Name = "B1",
                        Type = "int",
                        Comment = "comment"
                    },
                    new Property
                    {
                        Name = "B2",
                        Type = "int",
                        Comment = "comment"
                    }
                }
            };

            var properties = baseClassInfo.GetProperties(true).ToList();
            Assert.Equal(2, properties.Count);

            var classInfo1 = new ClassInfo
            {
                Name = "Class",
                BaseClassName = "BaseClass",
                BaseClass = baseClassInfo,
                Properties = new List<Property>
                {
                    new Property
                    {
                        Name = "F3",
                        Type = "int",
                        Comment = "comment"
                    },
                }
            };

            properties = classInfo1.GetProperties(true).ToList();
            Assert.Equal(3, properties.Count);

            properties = classInfo1.GetProperties(false).ToList();
            Assert.Single(properties);

            var classInfo2 = new ClassInfo
            {
                Name = "Class",
                BaseClassName = "ClassInfo1",
                BaseClass = classInfo1,
                Properties = new List<Property>
                {
                    new Property
                    {
                        Name = "F1",
                        Type = "int",
                        Comment = "comment"
                    },
                    new Property
                    {
                        Name = "F2",
                        Type = "int",
                        Comment = "comment"
                    },
                }
            };

            properties = classInfo2.GetProperties(true).ToList();
            Assert.Equal(5, properties.Count);
            Assert.Equal("F1", properties[0].Name);
            Assert.Equal("F2", properties[1].Name);
            Assert.Equal("F3", properties[2].Name);
            Assert.Equal("B1", properties[3].Name);
            Assert.Equal("B2", properties[4].Name);
        }
    }
}