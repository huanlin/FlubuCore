
//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Tasks.Docker.Swarm;

namespace FlubuCore.Context.FluentInterface.Docker
{
    public class Swarm
    {  
        
            
        /// <summary>
        /// Display and rotate the root CA
        /// </summary>
            public DockerSwarmCaTask SwarmCa()
            {
                return new DockerSwarmCaTask();
            }


            
        /// <summary>
        /// Initialize a swarm
        /// </summary>
            public DockerSwarmInitTask SwarmInit()
            {
                return new DockerSwarmInitTask();
            }


            
        /// <summary>
        /// Manage join tokens
        /// </summary>
            public DockerSwarmJoinTokenTask SwarmJoinToken(string worker)
            {
                return new DockerSwarmJoinTokenTask(worker);
            }


            
        /// <summary>
        /// Join a swarm as a node and/or manager
        /// </summary>
            public DockerSwarmJoinTask SwarmJoin(string host)
            {
                return new DockerSwarmJoinTask(host);
            }


            
        /// <summary>
        /// Leave the swarm
        /// </summary>
            public DockerSwarmLeaveTask SwarmLeave()
            {
                return new DockerSwarmLeaveTask();
            }


            
        /// <summary>
        /// Manage the unlock key
        /// </summary>
            public DockerSwarmUnlockKeyTask SwarmUnlockKey()
            {
                return new DockerSwarmUnlockKeyTask();
            }


            
        /// <summary>
        /// Update the swarm
        /// </summary>
            public DockerSwarmUpdateTask SwarmUpdate()
            {
                return new DockerSwarmUpdateTask();
            }

        
    }
}

