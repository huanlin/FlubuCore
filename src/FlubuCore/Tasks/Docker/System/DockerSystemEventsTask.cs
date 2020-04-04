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

namespace FlubuCore.Tasks.Docker.System
{
    public partial class DockerSystemEventsTask : ExternalProcessTaskBase<int, DockerSystemEventsTask>
    {
        public DockerSystemEventsTask()
        {
            ExecutablePath = "docker";
            WithArguments("system events");
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Filter output based on conditions provided
        /// </summary>
        [ArgKey("--filter")]
        public DockerSystemEventsTask Filter(string filter)
        {
            WithArgumentsKeyFromAttribute(filter.ToString());
            return this;
        }

        /// <summary>
        /// Format the output using the given Go template
        /// </summary>
        [ArgKey("--format")]
        public DockerSystemEventsTask Format(string format)
        {
            WithArgumentsKeyFromAttribute(format.ToString());
            return this;
        }

        /// <summary>
        /// Show all events created since timestamp
        /// </summary>
        [ArgKey("--since")]
        public DockerSystemEventsTask Since(string since)
        {
            WithArgumentsKeyFromAttribute(since.ToString());
            return this;
        }

        /// <summary>
        /// Stream events until this timestamp
        /// </summary>
        [ArgKey("--until")]
        public DockerSystemEventsTask Until(string until)
        {
            WithArgumentsKeyFromAttribute(until.ToString());
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            return base.DoExecute(context);
        }
    }
}