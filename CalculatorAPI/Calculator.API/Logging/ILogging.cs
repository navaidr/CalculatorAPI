using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Logging
{
   public interface ILogging
    {
        Task WriteInfoLog(string actionname, string input1, string input2);
        Task WriteErrorLog(string actionname, string input1, string input2);
    }
}
