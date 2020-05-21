using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.API.Helpers;
using Microsoft.Extensions.Configuration;

namespace Calculator.API.Configuration
{
    public class ConfigHelper : IConfig
    {
        private  IConfiguration _Configuration { get; }
        private  Dictionary<string, string> logconfig;

        public ConfigHelper(IConfiguration configuration)
        {
            _Configuration = configuration;
            logconfig = new Dictionary<string, string>();
        }


        /// <summary>
        /// Loading the Settings from the appsettings.json file
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetConfig()
        {
            logconfig.Add("ProcessAdd", _Configuration.GetSection(AppConstants.LogAdd).Value);
            logconfig.Add("ProcessSubtract", _Configuration.GetSection(AppConstants.LogSubtract).Value);
            logconfig.Add("ProcessMultiply", _Configuration.GetSection(AppConstants.LogMultiply).Value);
            logconfig.Add("ProcessDivide", _Configuration.GetSection(AppConstants.LogDivide).Value);
            return logconfig;
        }
    }
}
