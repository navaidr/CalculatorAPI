using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Logging
{
    public class DBLogging : ILogging
    {
        public Task WriteErrorLog(string actionname, string input1, string input2)
        {
            throw new NotImplementedException();
        }

        public Task WriteInfoLog(string actionname, string input1, string input2)
        {
            throw new NotImplementedException();
        }

     
    }
}
