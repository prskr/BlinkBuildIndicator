using System;
using System.Drawing;
using System.IO;
using BBI.Common.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace BBI.Common.Tests
{
    public class BlinkConfigSerializationTest
    {
        [Fact]
        public void TestSerializeConfig()
        {
            var targetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.json");
            var blinkConfig = new BlinkConfig
            {
                ColorConfig = new ColorConfig
                {
                    SuccessColor = Color.GreenYellow,
                    ErrorColor = Color.Red
                }
            };

            File.WriteAllText(targetPath, JsonConvert.SerializeObject(blinkConfig));
        }
    }
}