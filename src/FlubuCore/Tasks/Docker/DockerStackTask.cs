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

namespace FlubuCore.Tasks.Docker
{
    public partial class DockerStackTask : ExternalProcessTaskBase<int, DockerStackTask>
    {
        public DockerStackTask()
        {
            ExecutablePath = "docker";
            WithArguments("stack");
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Kubernetes config file
        /// </summary>
        [ArgKey("--kubeconfig")]
        public DockerStackTask Kubeconfig(string kubeconfig)
        {
            WithArgumentsKeyFromAttribute(kubeconfig.ToString());
            return this;
        }

        /// <summary>
        /// Orchestrator to use (swarm|kubernetes|all)
        /// </summary>
        [ArgKey("--orchestrator")]
        public DockerStackTask Orchestrator(string orchestrator)
        {
            WithArgumentsKeyFromAttribute(orchestrator.ToString());
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            return base.DoExecute(context);
        }
    }
}