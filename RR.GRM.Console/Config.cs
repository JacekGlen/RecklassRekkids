using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using RR.GRM.Core;

namespace RR.GRM.Console
{
    public class Config: ICoreSettings
    {
        public string FlatFileAssetPath { get; set; }
        public string FlatFilePartnerPath { get; set; }

        public Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            configuration.Bind(this);
        }
    }
}
