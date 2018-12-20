
//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Docker
{
     public partial class DockerRunTask : ExternalProcessTaskBase<DockerRunTask>
     {
        private string _image;
private string _command;
private string[] _arg;

        
        public DockerRunTask(string image,  string command,  params string[] arg)
        {
            ExecutablePath = "docker";
            WithArguments("run");
_image = image;
_command = command;
_arg = arg;

        }

        protected override string Description { get; set; }
        
        /// <summary>
        /// Add a custom host-to-IP mapping (host:ip)
        /// </summary>
        public DockerRunTask AddHost(string addHost)
        {
            WithArgumentsValueRequired("add-host", addHost.ToString());
            return this;
        }

        /// <summary>
        /// Attach to STDIN, STDOUT or STDERR
        /// </summary>
        public DockerRunTask Attach(string attach)
        {
            WithArgumentsValueRequired("attach", attach.ToString());
            return this;
        }

        /// <summary>
        /// Block IO (relative weight), between 10 and 1000, or 0 to disable (default 0)

        /// </summary>
        public DockerRunTask BlkioWeight(string blkioWeight)
        {
            WithArgumentsValueRequired("blkio-weight", blkioWeight.ToString());
            return this;
        }

        /// <summary>
        /// Block IO weight (relative device weight)
        /// </summary>
        public DockerRunTask BlkioWeightDevice(string blkioWeightDevice)
        {
            WithArgumentsValueRequired("blkio-weight-device", blkioWeightDevice.ToString());
            return this;
        }

        /// <summary>
        /// Add Linux capabilities
        /// </summary>
        public DockerRunTask CapAdd(string capAdd)
        {
            WithArgumentsValueRequired("cap-add", capAdd.ToString());
            return this;
        }

        /// <summary>
        /// Drop Linux capabilities
        /// </summary>
        public DockerRunTask CapDrop(string capDrop)
        {
            WithArgumentsValueRequired("cap-drop", capDrop.ToString());
            return this;
        }

        /// <summary>
        /// Optional parent cgroup for the container
        /// </summary>
        public DockerRunTask CgroupParent(string cgroupParent)
        {
            WithArgumentsValueRequired("cgroup-parent", cgroupParent.ToString());
            return this;
        }

        /// <summary>
        /// Write the container ID to the file
        /// </summary>
        public DockerRunTask Cidfile(string cidfile)
        {
            WithArgumentsValueRequired("cidfile", cidfile.ToString());
            return this;
        }

        /// <summary>
        /// CPU count (Windows only)
        /// </summary>
        public DockerRunTask CpuCount(long cpuCount)
        {
            WithArgumentsValueRequired("cpu-count", cpuCount.ToString());
            return this;
        }

        /// <summary>
        /// CPU percent (Windows only)
        /// </summary>
        public DockerRunTask CpuPercent(long cpuPercent)
        {
            WithArgumentsValueRequired("cpu-percent", cpuPercent.ToString());
            return this;
        }

        /// <summary>
        /// Limit CPU CFS (Completely Fair Scheduler) period
        /// </summary>
        public DockerRunTask CpuPeriod(long cpuPeriod)
        {
            WithArgumentsValueRequired("cpu-period", cpuPeriod.ToString());
            return this;
        }

        /// <summary>
        /// Limit CPU CFS (Completely Fair Scheduler) quota
        /// </summary>
        public DockerRunTask CpuQuota(long cpuQuota)
        {
            WithArgumentsValueRequired("cpu-quota", cpuQuota.ToString());
            return this;
        }

        /// <summary>
        /// Limit CPU real-time period in microseconds
        /// </summary>
        public DockerRunTask CpuRtPeriod(long cpuRtPeriod)
        {
            WithArgumentsValueRequired("cpu-rt-period", cpuRtPeriod.ToString());
            return this;
        }

        /// <summary>
        /// Limit CPU real-time runtime in microseconds
        /// </summary>
        public DockerRunTask CpuRtRuntime(long cpuRtRuntime)
        {
            WithArgumentsValueRequired("cpu-rt-runtime", cpuRtRuntime.ToString());
            return this;
        }

        /// <summary>
        /// CPU shares (relative weight)
        /// </summary>
        public DockerRunTask CpuShares(long cpuShares)
        {
            WithArgumentsValueRequired("cpu-shares", cpuShares.ToString());
            return this;
        }

        /// <summary>
        /// Number of CPUs
        /// </summary>
        public DockerRunTask Cpus(decimal cpus)
        {
            WithArgumentsValueRequired("cpus", cpus.ToString());
            return this;
        }

        /// <summary>
        /// CPUs in which to allow execution (0-3, 0,1)
        /// </summary>
        public DockerRunTask CpusetCpus(string cpusetCpus)
        {
            WithArgumentsValueRequired("cpuset-cpus", cpusetCpus.ToString());
            return this;
        }

        /// <summary>
        /// MEMs in which to allow execution (0-3, 0,1)
        /// </summary>
        public DockerRunTask CpusetMems(string cpusetMems)
        {
            WithArgumentsValueRequired("cpuset-mems", cpusetMems.ToString());
            return this;
        }

        /// <summary>
        /// Run container in background and print container ID
        /// </summary>
        public DockerRunTask Detach()
        {
            WithArguments("detach");
            return this;
        }

        /// <summary>
        /// Override the key sequence for detaching a container
        /// </summary>
        public DockerRunTask DetachKeys(string detachKeys)
        {
            WithArgumentsValueRequired("detach-keys", detachKeys.ToString());
            return this;
        }

        /// <summary>
        /// Add a host device to the container
        /// </summary>
        public DockerRunTask Device(string device)
        {
            WithArgumentsValueRequired("device", device.ToString());
            return this;
        }

        /// <summary>
        /// Add a rule to the cgroup allowed devices list
        /// </summary>
        public DockerRunTask DeviceCgroupRule(string deviceCgroupRule)
        {
            WithArgumentsValueRequired("device-cgroup-rule", deviceCgroupRule.ToString());
            return this;
        }

        /// <summary>
        /// Limit read rate (bytes per second) from a device
        /// </summary>
        public DockerRunTask DeviceReadBps(string deviceReadBps)
        {
            WithArgumentsValueRequired("device-read-bps", deviceReadBps.ToString());
            return this;
        }

        /// <summary>
        /// Limit read rate (IO per second) from a device
        /// </summary>
        public DockerRunTask DeviceReadIops(string deviceReadIops)
        {
            WithArgumentsValueRequired("device-read-iops", deviceReadIops.ToString());
            return this;
        }

        /// <summary>
        /// Limit write rate (bytes per second) to a device
        /// </summary>
        public DockerRunTask DeviceWriteBps(string deviceWriteBps)
        {
            WithArgumentsValueRequired("device-write-bps", deviceWriteBps.ToString());
            return this;
        }

        /// <summary>
        /// Limit write rate (IO per second) to a device
        /// </summary>
        public DockerRunTask DeviceWriteIops(string deviceWriteIops)
        {
            WithArgumentsValueRequired("device-write-iops", deviceWriteIops.ToString());
            return this;
        }

        /// <summary>
        /// Skip image verification
        /// </summary>
        public DockerRunTask DisableContentTrust()
        {
            WithArguments("disable-content-trust");
            return this;
        }

        /// <summary>
        /// Set custom DNS servers
        /// </summary>
        public DockerRunTask Dns(string dns)
        {
            WithArgumentsValueRequired("dns", dns.ToString());
            return this;
        }

        /// <summary>
        /// Set DNS options
        /// </summary>
        public DockerRunTask DnsOpt(string dnsOpt)
        {
            WithArgumentsValueRequired("dns-opt", dnsOpt.ToString());
            return this;
        }

        /// <summary>
        /// Set DNS options
        /// </summary>
        public DockerRunTask DnsOption(string dnsOption)
        {
            WithArgumentsValueRequired("dns-option", dnsOption.ToString());
            return this;
        }

        /// <summary>
        /// Set custom DNS search domains
        /// </summary>
        public DockerRunTask DnsSearch(string dnsSearch)
        {
            WithArgumentsValueRequired("dns-search", dnsSearch.ToString());
            return this;
        }

        /// <summary>
        /// Overwrite the default ENTRYPOINT of the image
        /// </summary>
        public DockerRunTask Entrypoint(string entrypoint)
        {
            WithArgumentsValueRequired("entrypoint", entrypoint.ToString());
            return this;
        }

        /// <summary>
        /// Set environment variables
        /// </summary>
        public DockerRunTask Env(string env)
        {
            WithArgumentsValueRequired("env", env.ToString());
            return this;
        }

        /// <summary>
        /// Read in a file of environment variables
        /// </summary>
        public DockerRunTask EnvFile(string envFile)
        {
            WithArgumentsValueRequired("env-file", envFile.ToString());
            return this;
        }

        /// <summary>
        /// Expose a port or a range of ports
        /// </summary>
        public DockerRunTask Expose(string expose)
        {
            WithArgumentsValueRequired("expose", expose.ToString());
            return this;
        }

        /// <summary>
        /// Add additional groups to join
        /// </summary>
        public DockerRunTask GroupAdd(string groupAdd)
        {
            WithArgumentsValueRequired("group-add", groupAdd.ToString());
            return this;
        }

        /// <summary>
        /// Command to run to check health
        /// </summary>
        public DockerRunTask HealthCmd(string healthCmd)
        {
            WithArgumentsValueRequired("health-cmd", healthCmd.ToString());
            return this;
        }

        /// <summary>
        /// Time between running the check (ms|s|m|h) (default 0s)
        /// </summary>
        public DockerRunTask HealthInterval(string healthInterval)
        {
            WithArgumentsValueRequired("health-interval", healthInterval.ToString());
            return this;
        }

        /// <summary>
        /// Consecutive failures needed to report unhealthy
        /// </summary>
        public DockerRunTask HealthRetries(int healthRetries)
        {
            WithArgumentsValueRequired("health-retries", healthRetries.ToString());
            return this;
        }

        /// <summary>
        /// Start period for the container to initialize before starting health-retries countdown (ms|s|m|h) (default 0s)

        /// </summary>
        public DockerRunTask HealthStartPeriod(string healthStartPeriod)
        {
            WithArgumentsValueRequired("health-start-period", healthStartPeriod.ToString());
            return this;
        }

        /// <summary>
        /// Maximum time to allow one check to run (ms|s|m|h) (default 0s)

        /// </summary>
        public DockerRunTask HealthTimeout(string healthTimeout)
        {
            WithArgumentsValueRequired("health-timeout", healthTimeout.ToString());
            return this;
        }

        /// <summary>
        /// Print usage
        /// </summary>
        public DockerRunTask Help()
        {
            WithArguments("help");
            return this;
        }

        /// <summary>
        /// Container host name
        /// </summary>
        public DockerRunTask Hostname(string hostname)
        {
            WithArgumentsValueRequired("hostname", hostname.ToString());
            return this;
        }

        /// <summary>
        /// Run an init inside the container that forwards signals and reaps processes

        /// </summary>
        public DockerRunTask Init()
        {
            WithArguments("init");
            return this;
        }

        /// <summary>
        /// Keep STDIN open even if not attached
        /// </summary>
        public DockerRunTask Interactive()
        {
            WithArguments("interactive");
            return this;
        }

        /// <summary>
        /// Maximum IO bandwidth limit for the system drive (Windows only)

        /// </summary>
        public DockerRunTask IoMaxbandwidth(string ioMaxbandwidth)
        {
            WithArgumentsValueRequired("io-maxbandwidth", ioMaxbandwidth.ToString());
            return this;
        }

        /// <summary>
        /// Maximum IOps limit for the system drive (Windows only)
        /// </summary>
        public DockerRunTask IoMaxiops(ulong ioMaxiops)
        {
            WithArgumentsValueRequired("io-maxiops", ioMaxiops.ToString());
            return this;
        }

        /// <summary>
        /// IPv4 address (e.g., 172.30.100.104)
        /// </summary>
        public DockerRunTask Ip(string ip)
        {
            WithArgumentsValueRequired("ip", ip.ToString());
            return this;
        }

        /// <summary>
        /// IPv6 address (e.g., 2001:db8::33)
        /// </summary>
        public DockerRunTask Ip6(string ip6)
        {
            WithArgumentsValueRequired("ip6", ip6.ToString());
            return this;
        }

        /// <summary>
        /// IPC mode to use
        /// </summary>
        public DockerRunTask Ipc(string ipc)
        {
            WithArgumentsValueRequired("ipc", ipc.ToString());
            return this;
        }

        /// <summary>
        /// Container isolation technology
        /// </summary>
        public DockerRunTask Isolation(string isolation)
        {
            WithArgumentsValueRequired("isolation", isolation.ToString());
            return this;
        }

        /// <summary>
        /// Kernel memory limit
        /// </summary>
        public DockerRunTask KernelMemory(string kernelMemory)
        {
            WithArgumentsValueRequired("kernel-memory", kernelMemory.ToString());
            return this;
        }

        /// <summary>
        /// Set meta data on a container
        /// </summary>
        public DockerRunTask Label(string label)
        {
            WithArgumentsValueRequired("label", label.ToString());
            return this;
        }

        /// <summary>
        /// Read in a line delimited file of labels
        /// </summary>
        public DockerRunTask LabelFile(string labelFile)
        {
            WithArgumentsValueRequired("label-file", labelFile.ToString());
            return this;
        }

        /// <summary>
        /// Add link to another container
        /// </summary>
        public DockerRunTask Link(string link)
        {
            WithArgumentsValueRequired("link", link.ToString());
            return this;
        }

        /// <summary>
        /// Container IPv4/IPv6 link-local addresses
        /// </summary>
        public DockerRunTask LinkLocalIp(string linkLocalIp)
        {
            WithArgumentsValueRequired("link-local-ip", linkLocalIp.ToString());
            return this;
        }

        /// <summary>
        /// Logging driver for the container
        /// </summary>
        public DockerRunTask LogDriver(string logDriver)
        {
            WithArgumentsValueRequired("log-driver", logDriver.ToString());
            return this;
        }

        /// <summary>
        /// Log driver options
        /// </summary>
        public DockerRunTask LogOpt(string logOpt)
        {
            WithArgumentsValueRequired("log-opt", logOpt.ToString());
            return this;
        }

        /// <summary>
        /// Container MAC address (e.g., 92:d0:c6:0a:29:33)
        /// </summary>
        public DockerRunTask MacAddress(string macAddress)
        {
            WithArgumentsValueRequired("mac-address", macAddress.ToString());
            return this;
        }

        /// <summary>
        /// Memory limit
        /// </summary>
        public DockerRunTask Memory(string memory)
        {
            WithArgumentsValueRequired("memory", memory.ToString());
            return this;
        }

        /// <summary>
        /// Memory soft limit
        /// </summary>
        public DockerRunTask MemoryReservation(string memoryReservation)
        {
            WithArgumentsValueRequired("memory-reservation", memoryReservation.ToString());
            return this;
        }

        /// <summary>
        /// Swap limit equal to memory plus swap: '-1' to enable unlimited swap

        /// </summary>
        public DockerRunTask MemorySwap(string memorySwap)
        {
            WithArgumentsValueRequired("memory-swap", memorySwap.ToString());
            return this;
        }

        /// <summary>
        /// Tune container memory swappiness (0 to 100)
        /// </summary>
        public DockerRunTask MemorySwappiness(long memorySwappiness)
        {
            WithArgumentsValueRequired("memory-swappiness", memorySwappiness.ToString());
            return this;
        }

        /// <summary>
        /// Attach a filesystem mount to the container
        /// </summary>
        public DockerRunTask Mount(string mount)
        {
            WithArgumentsValueRequired("mount", mount.ToString());
            return this;
        }

        /// <summary>
        /// Assign a name to the container
        /// </summary>
        public DockerRunTask Name(string name)
        {
            WithArgumentsValueRequired("name", name.ToString());
            return this;
        }

        /// <summary>
        /// Connect a container to a network
        /// </summary>
        public DockerRunTask Net(string net)
        {
            WithArgumentsValueRequired("net", net.ToString());
            return this;
        }

        /// <summary>
        /// Add network-scoped alias for the container
        /// </summary>
        public DockerRunTask NetAlias(string netAlias)
        {
            WithArgumentsValueRequired("net-alias", netAlias.ToString());
            return this;
        }

        /// <summary>
        /// Connect a container to a network
        /// </summary>
        public DockerRunTask Network(string network)
        {
            WithArgumentsValueRequired("network", network.ToString());
            return this;
        }

        /// <summary>
        /// Add network-scoped alias for the container
        /// </summary>
        public DockerRunTask NetworkAlias(string networkAlias)
        {
            WithArgumentsValueRequired("network-alias", networkAlias.ToString());
            return this;
        }

        /// <summary>
        /// Disable any container-specified HEALTHCHECK
        /// </summary>
        public DockerRunTask NoHealthcheck()
        {
            WithArguments("no-healthcheck");
            return this;
        }

        /// <summary>
        /// Disable OOM Killer
        /// </summary>
        public DockerRunTask OomKillDisable()
        {
            WithArguments("oom-kill-disable");
            return this;
        }

        /// <summary>
        /// Tune host's OOM preferences (-1000 to 1000)
        /// </summary>
        public DockerRunTask OomScoreAdj(int oomScoreAdj)
        {
            WithArgumentsValueRequired("oom-score-adj", oomScoreAdj.ToString());
            return this;
        }

        /// <summary>
        /// PID namespace to use
        /// </summary>
        public DockerRunTask Pid(string pid)
        {
            WithArgumentsValueRequired("pid", pid.ToString());
            return this;
        }

        /// <summary>
        /// Tune container pids limit (set -1 for unlimited)
        /// </summary>
        public DockerRunTask PidsLimit(long pidsLimit)
        {
            WithArgumentsValueRequired("pids-limit", pidsLimit.ToString());
            return this;
        }

        /// <summary>
        /// Set platform if server is multi-platform capable
        /// </summary>
        public DockerRunTask Platform(string platform)
        {
            WithArgumentsValueRequired("platform", platform.ToString());
            return this;
        }

        /// <summary>
        /// Give extended privileges to this container
        /// </summary>
        public DockerRunTask Privileged()
        {
            WithArguments("privileged");
            return this;
        }

        /// <summary>
        /// Publish a container's port(s) to the host
        /// </summary>
        public DockerRunTask Publish(string publish)
        {
            WithArgumentsValueRequired("publish", publish.ToString());
            return this;
        }

        /// <summary>
        /// Publish all exposed ports to random ports
        /// </summary>
        public DockerRunTask PublishAll()
        {
            WithArguments("publish-all");
            return this;
        }

        /// <summary>
        /// Mount the container's root filesystem as read only
        /// </summary>
        public DockerRunTask ReadOnly()
        {
            WithArguments("read-only");
            return this;
        }

        /// <summary>
        /// Restart policy to apply when a container exits
        /// </summary>
        public DockerRunTask Restart(string restart)
        {
            WithArgumentsValueRequired("restart", restart.ToString());
            return this;
        }

        /// <summary>
        /// Automatically remove the container when it exits
        /// </summary>
        public DockerRunTask Rm()
        {
            WithArguments("rm");
            return this;
        }

        /// <summary>
        /// Runtime to use for this container
        /// </summary>
        public DockerRunTask Runtime(string runtime)
        {
            WithArgumentsValueRequired("runtime", runtime.ToString());
            return this;
        }

        /// <summary>
        /// Security Options
        /// </summary>
        public DockerRunTask SecurityOpt(string securityOpt)
        {
            WithArgumentsValueRequired("security-opt", securityOpt.ToString());
            return this;
        }

        /// <summary>
        /// Size of /dev/shm
        /// </summary>
        public DockerRunTask ShmSize(string shmSize)
        {
            WithArgumentsValueRequired("shm-size", shmSize.ToString());
            return this;
        }

        /// <summary>
        /// Proxy received signals to the process
        /// </summary>
        public DockerRunTask SigProxy()
        {
            WithArguments("sig-proxy");
            return this;
        }

        /// <summary>
        /// Signal to stop a container
        /// </summary>
        public DockerRunTask StopSignal(string stopSignal)
        {
            WithArgumentsValueRequired("stop-signal", stopSignal.ToString());
            return this;
        }

        /// <summary>
        /// Timeout (in seconds) to stop a container
        /// </summary>
        public DockerRunTask StopTimeout(int stopTimeout)
        {
            WithArgumentsValueRequired("stop-timeout", stopTimeout.ToString());
            return this;
        }

        /// <summary>
        /// Storage driver options for the container
        /// </summary>
        public DockerRunTask StorageOpt(string storageOpt)
        {
            WithArgumentsValueRequired("storage-opt", storageOpt.ToString());
            return this;
        }

        /// <summary>
        /// Sysctl options
        /// </summary>
        public DockerRunTask Sysctl(string sysctl)
        {
            WithArgumentsValueRequired("sysctl", sysctl.ToString());
            return this;
        }

        /// <summary>
        /// Mount a tmpfs directory
        /// </summary>
        public DockerRunTask Tmpfs(string tmpfs)
        {
            WithArgumentsValueRequired("tmpfs", tmpfs.ToString());
            return this;
        }

        /// <summary>
        /// Allocate a pseudo-TTY
        /// </summary>
        public DockerRunTask Tty()
        {
            WithArguments("tty");
            return this;
        }

        /// <summary>
        /// Ulimit options
        /// </summary>
        public DockerRunTask Ulimit(string ulimit)
        {
            WithArgumentsValueRequired("ulimit", ulimit.ToString());
            return this;
        }

        /// <summary>
        /// Username or UID (format: <name|uid>[:<group|gid>])
        /// </summary>
        public DockerRunTask User(string user)
        {
            WithArgumentsValueRequired("user", user.ToString());
            return this;
        }

        /// <summary>
        /// User namespace to use
        /// </summary>
        public DockerRunTask Userns(string userns)
        {
            WithArgumentsValueRequired("userns", userns.ToString());
            return this;
        }

        /// <summary>
        /// UTS namespace to use
        /// </summary>
        public DockerRunTask Uts(string uts)
        {
            WithArgumentsValueRequired("uts", uts.ToString());
            return this;
        }

        /// <summary>
        /// Bind mount a volume
        /// </summary>
        public DockerRunTask Volume(string volume)
        {
            WithArgumentsValueRequired("volume", volume.ToString());
            return this;
        }

        /// <summary>
        /// Optional volume driver for the container
        /// </summary>
        public DockerRunTask VolumeDriver(string volumeDriver)
        {
            WithArgumentsValueRequired("volume-driver", volumeDriver.ToString());
            return this;
        }

        /// <summary>
        /// Mount volumes from the specified container(s)
        /// </summary>
        public DockerRunTask VolumesFrom(string volumesFrom)
        {
            WithArgumentsValueRequired("volumes-from", volumesFrom.ToString());
            return this;
        }

        /// <summary>
        /// Working directory inside the container
        /// </summary>
        public DockerRunTask Workdir(string workdir)
        {
            WithArgumentsValueRequired("workdir", workdir.ToString());
            return this;
        }
        protected override int DoExecute(ITaskContextInternal context)
        {
             WithArguments(_image);
 WithArguments(_command);
 WithArguments(_arg);

            return base.DoExecute(context);
        }

     }
}