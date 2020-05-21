using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



namespace Calculator.API.Configuration
{



    /// <summary>
    /// To Get The configuration from DB, just for the sake of architecture written class here.
    /// </summary>
    public class DbConfigHelper : IConfig
    {
        private IConfiguration _Configuration { get; }
        private Dictionary<string, string> logconfig;

        public DbConfigHelper(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public Dictionary<string, string> GetConfig() 
        {
            //Method Not Implemented
            throw new NotImplementedException();

        }
    }
}
