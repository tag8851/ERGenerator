using ERGenerator.DataAccess.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;
using System.Xml;

namespace ERGenerator.DataAccess.Repositories
{
    public interface IRoslynParser
    {
        List<ClassModel> GetClassModel(string path);
    }
    public class RoslynParser : IRoslynParser
    {
        public RoslynParser()
        {
        }
        public List<ClassModel> GetClassModel(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var source = reader.ReadToEnd();
                var tree = CSharpSyntaxTree.ParseText(source);
                var root = tree.GetCompilationUnitRoot();

                var results = new List<ClassModel>();

                foreach (var cSyntax in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
                {
                    var nameSpace = cSyntax.Parent as NamespaceDeclarationSyntax;

                    var c = new ClassModel
                    {
                        BaseClass = cSyntax.BaseList?.Types[0].ToString(),
                        Name = cSyntax.Identifier.ToString(),
                        NameSpace = nameSpace?.Name.ToString(),
                    };

                    foreach (var pSyntax in cSyntax.Members.OfType<PropertyDeclarationSyntax>())
                    {
                        var p = new ClassModel.PropertyModel
                        {
                            Name = pSyntax.Identifier.Text,
                            Type = pSyntax.Type.ToString(),
                            Comment = GetComment(pSyntax)
                        };
                        c.Properties.Add(p);
                    }
                    results.Add(c);
                }
                return results;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        private string GetComment(PropertyDeclarationSyntax pSyntax)
        {
            var  result = string.Empty;

            var commentTrival = pSyntax.GetLeadingTrivia().FirstOrDefault(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia));
            var comment = commentTrival.GetStructure()?.ToString();

            var doc = GetXmlDocument(comment);
            if (doc != null)
            {
                result = doc.SelectSingleNode("/summary")?.InnerText;
            }
            else
            { 
                result = comment;
            }
            return RemoveAnyChar(result);
        }
        private static XmlDocument GetXmlDocument(string str)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(str);

                return doc;
            }
            catch
            {
                return null;
            }
        }
        private static string RemoveAnyChar(string str)
        {
            if (string.IsNullOrEmpty(str)) return null;

            str = Regex.Replace(str, "\\s", "");
            str = Regex.Replace(str, "///", "");
            return str;
        }
    }
}
