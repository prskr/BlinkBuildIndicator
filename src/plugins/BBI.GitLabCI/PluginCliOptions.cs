using CommandLine;

namespace BBI.GitLabCI
{
    /// <summary>
    ///     Options parsed from the CLI args passed to the main method
    /// </summary>
    public class PluginCliOptions
    {
        /// <summary>
        ///     Name the plugin uses for registration
        ///     can be used to register the plugin multiple times for multiple pipelines
        /// </summary>
        [Option('n', "name", Required = false, HelpText = "Name the plugin will use for registration")]
        public string PluginName { get; set; } = "GitLabCI";
        
        /// <summary>
        ///     Port passed to the plugin by the supervisor
        ///     Port availability has to be checked by the supervisor
        /// </summary>
        [Option('p', "port", Required = true, HelpText = "Port the plugin will be listening on")]
        public int LaunchPort { get; set; }

        /// <summary>
        ///     IP or hostname the plugin will use for binding
        ///     should be localhost to avoid remote access
        /// </summary>
        [Option('i', "ip", Required = true, HelpText = "IP the plugin will be listening on")]
        public string LaunchIp { get; set; }
    }
}