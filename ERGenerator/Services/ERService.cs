using ERGenerator.UseCase;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using static ERGenerator.AppSettings;

namespace ERGenerator.Application
{
    public interface IERService
    {
        void Execute();
        void MakeER(string templateFilePath, string projectFolderPath, string outputFilePath);
    }
    public class ERService : IERService
    {
        private readonly IClassInfoUseCase _useCase;
        private readonly ILogger<ERService> _logger;
        private readonly ERServiceSettings _settings;
        public ERService(IClassInfoUseCase useCase, ILogger<ERService> logger, IOptions<ERServiceSettings> options)
        {
            _useCase = useCase;
            _logger = logger;
            _settings = options.Value;
        }
        public void Execute()
        {
            try
            {
                var args = Environment.GetCommandLineArgs();
                
                if(args.Length != 4)
                {
                    throw new ApplicationException("arguments error!");
                }

                MakeER(args[1], args[2], args[3]);
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                Environment.Exit(1);
            }
        }
        public void MakeER(string templateFilePath, string projectFolderPath, string outputFilePath)
        {
            _logger.LogInformation($"start {templateFilePath} {projectFolderPath} {outputFilePath}");
           var attr = _settings.ReplaceChar;
            var classes = _useCase.ReadClass(projectFolderPath);

            using (var reader = new StreamReader(templateFilePath))
            using (var writer = new StreamWriter(outputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim();

                    if (line.StartsWith(attr))
                    {
                        var className = line.Substring(attr.Length);
                        var c = classes.Where(x => x.Name == className).FirstOrDefault();
                        if(c != null)
                        {
                            writer.WriteLine($"  {c.Name} {{");
                            foreach(var p in c.GetProperties(true))
                            {
                                writer.WriteLine($"    {p.Type} {p.Name} \"{p.Comment}\"");
                            }
                            writer.WriteLine($"  }}");
                            _logger.LogInformation($"found class {className}");

                        }
                        else
                        {
                            _logger.LogWarning($"not found class {className}");
                        }
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
