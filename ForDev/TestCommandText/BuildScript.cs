using System;
using System.Drawing;
using FlubuCore.Context;
using FlubuCore.Context.Attributes.BuildProperties;
using FlubuCore.IO;
using FlubuCore.Scripting;
using FlubuCore.Tasks.Attributes;
using FlubuCore.Tasks.Versioning;

namespace TestCommandText
{
    public class BuildScript : DefaultBuildScript
    {
        public FullPath OutputDir => RootDirectory.CombineWith(@"bin");

        [SolutionFileName]
        public string SolutionFileName => "TestCommandText.sln";

        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release"; // Debug or Release

        protected override void ConfigureBuildProperties(IBuildPropertiesContext context)
        {
            context.Properties.Set(BuildProps.ProductRootDir, @"d:\Work\GitHub\FlubuCore\ForDev\TestCommandText");
        }

        protected override void ConfigureTargets(ITaskContext session)
        {
            var compile = session.CreateTarget("compile")
                .SetDescription("Compile the solution.")
                .AddCoreTask(x => x.Build()
                    .OnError((context, ex) => 
                    {
                        context.LogError($"糟糕, 編譯失敗了: {ex}", Color.Red);
                        
                    })
                );

            var test = session.CreateTarget("test")
                .SetDescription("test")
                .DependsOn(compile)
                .Do(c => { throw new Exception("test error"); });
        }
    }
}
