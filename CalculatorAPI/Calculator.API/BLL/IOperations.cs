using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.BLL
{
    public interface IOperations
    {

         Task<decimal> ProcessAdd(string num1,string num2);
         Task<decimal> ProcessSubtract(string num1, string num2);
        Task<decimal> ProcessMultiply(string num1, string num2);
        Task<decimal> ProcessDivide(string num1, string num2);
    }
}
