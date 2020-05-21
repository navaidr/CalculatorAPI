using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Configuration
{
    public interface IConfig
    {
        public Dictionary<string, string> GetConfig();
    }
}
