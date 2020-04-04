//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Attributes;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Docker.Network
{
    public partial class DockerNetworkLsTask : ExternalProcessTaskBase<int, DockerNetworkLsTask>
    {
        public DockerNetworkLsTask()
        {
            ExecutablePath = "docker";
            WithArguments("network ls");
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Provide filter values (e.g. 'driver=bridge')
        /// </summary>
        [ArgKey("--filter")]
        public DockerNetworkLsTask Filter(string filter)
        {
            WithArgumentsKeyFromAttribute(filter.ToString());
            return this;
        }

        /// <summary>
        /// Pretty-print networks using a Go template
        /// </summary>
        [ArgKey("--format")]
        public DockerNetworkLsTask Format(string format)
        {
            WithArgumentsKeyFromAttribute(format.ToString());
            return this;
        }

        /// <summary>
        /// Do not truncate the output
        /// </summary>
        [ArgKey("--no-trunc")]
        public DockerNetworkLsTask NoTrunc()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Only display network IDs
        /// </summary>
        [ArgKey("--quiet")]
        public DockerNetworkLsTask Quiet()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            return base.DoExecute(context);
        }
    }
}