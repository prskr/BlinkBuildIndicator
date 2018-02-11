using System;
using System.Threading;
using BBI.Common.Configuration;
using BBI.Common.Protobuf.PluginHost;
using BBI.Service.gRPC;
using Blink1;
using Blink1.ColorProcessor;
using Grpc.Core;
using NLog;
using Blink = Blink1.Blink1;

namespace BBI.Service
{
    public class BlinkService : IDisposable
    {
        private readonly IBlink1 _blink;
        private readonly BlinkConfig _config;
        private readonly Logger _logger;
        private readonly Timer _pollingTimer;
        private readonly Action<IColorProcessor> _setColor;

        public BlinkService(BlinkConfig config)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _config = config;
            _logger.Debug("Initializing Timer");
            /*_pollingTimer = new Timer(_config.TeamCityConfig.PollingInterval)
            {
                Enabled = true,
                AutoReset = true
            };*/

            _blink = new Blink();

            _logger.Debug("Initialize TeamCity connection");
            //_teamCityClient = new TeamCityClient(_config.TeamCityConfig.HostName, _config.TeamCityConfig.UseSsl);
            _setColor = color =>
            {
                _logger.Debug("Updating Blink(1) indicator");
                if (_blink.IsConnected)
                    _blink.SetColor(color);
            };

            var server = new Server
            {
                Services = {CIPluginHost.BindService(new CIPluginHostImpl())}
            };
        }

        public void Dispose()
        {
            _logger.Debug("Shutdown service. Releasing connection to Blink(1) device and terminate timer.");
            _blink?.Close();
            _blink?.Dispose();
            _pollingTimer?.Dispose();
        }

        public void OnStarting()
        {
            _logger.Debug("Connecting to TeamCity");
            try
            {
                //_teamCityClient.Connect(_config.TeamCityConfig.UserName, _config.TeamCityConfig.Password);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Failed to connect to TeamCity instance");
                throw;
            }

            try
            {
                _blink.Open();
            }
            catch (Exception e)
            {
                _logger.Error(e, "Failed to connect to Blink(1) device");
                throw;
            }

            /*if (!_teamCityClient.Authenticate())
            {
                _logger.Error("Failed to authenticate to TeamCity");
                throw new TCConectionFailException("Error while authenticating to teamcity");
            }*/

            _logger.Debug("Starting timer");
            /*_pollingTimer.Elapsed += (sender, args) => OnUpdate();
            _pollingTimer.Start();*/
        }

        public void OnStopping()
        {
            _logger.Debug("Stopping timer");
            //_pollingTimer.Stop();
        }

        private void OnUpdate()
        {
            //var tcConfig = _config.TeamCityConfig;
            var colorConfig = _config.ColorConfig;

            _logger.Debug("Getting latest build status");
            /*var latestBuild =
                _teamCityClient
                    .Builds
                    .ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(tcConfig.BuildConfigurationId), branch: tcConfig.Branch, maxResults: 1))
                    .SingleOrDefault();*/

            /*if (latestBuild != null)
                switch (latestBuild.Status)
                {
                    case "SUCCESS":
                        _setColor(colorConfig.SuccessColor.ToRgb());
                        break;
                    default:
                        _setColor(colorConfig.ErrorColor.ToRgb());
                        break;
                }*/
        }
    }
}