using CommandLine;

namespace BBI.GitLabCI
{
    public class PluginCliOptions
    {
        [Option('n', "name", Required = false, HelpText = "Name the plugin will use for registration")]
        public string PluginName { get; set; } = "GitLabCI";
        
        [Option('p', "port", Required = true, HelpText = "Port the plugin will be listening on")]
        public int LaunchPort { get; set; }

        [Option('i', "ip", Required = true, HelpText = "IP the plugin will be listening on")]
        public string LaunchIp { get; set; }
    }
}