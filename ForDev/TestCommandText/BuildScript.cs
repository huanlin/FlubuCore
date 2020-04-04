using System;
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
        protected new FullPath RootDirectory => new FullPath(@"d:\Work\GitHub\FlubuCore\ForDev\TestCommandText\");

        public FullPath OutputDir => RootDirectory.CombineWith(@"bin");

        [SolutionFileName]
        public string SolutionFileName => RootDirectory.CombineWith("TestCommandText.sln");

        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release"; // Debug or Release

        public BuildVersion ProductVersion { get; set; } = new BuildVersion();

        protected override void ConfigureBuildProperties(IBuildPropertiesContext context)
        {
            ProductVersion.Version = new Version("3.0.0");
        }

        protected override void ConfigureTargets(ITaskContext session)
        {
            var compile = session.CreateTarget("compile")
                .SetDescription("Compile the solution.")
                .AddCoreTask(x => x.Restore())
                .AddCoreTask(x => x.Build()
                    .Output(OutputDir)
                    .Version(ProductVersion.Version.ToString()));
        }
    }
}
