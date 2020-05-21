using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.API.Configuration;
using Calculator.API.Helpers;
using Calculator.API.Logging;
using Microsoft.Extensions.Configuration;

namespace Calculator.API.BLL
{
    public class Operations : IOperations
    {
        private readonly IValidate _validate;
        private readonly Helper _helper;
        private decimal _firstNumber;
        private decimal _secondNumber;

        public Operations(IConfiguration iConfig,ILogging iLogging)
        {
            _validate = new Validations();
            _helper = new Helper(iConfig, iLogging);
        }


        /// <summary>
        /// Function responsible to Validate and Convert the input parameters
        /// </summary>
        /// <param name="firstNumber">input parameter 1</param>
        /// <param name="secondNumber">input parameter 2</param>
        private void Process(string firstNumber, string secondNumber)
        {
            if (_validate.Validate(firstNumber, secondNumber))
            {
                _firstNumber = Convert.ToDecimal(firstNumber);
                _secondNumber = Convert.ToDecimal(secondNumber);
            }
        }



        /// <summary>
        /// Main Addition Function
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the addition of Input Parameters </returns>
        public async Task<decimal> ProcessAdd(string firstNumber, string secondNumber)
        {

            //Check defined Configuration and do asynchornus logging accordingly if needed
            await _helper.Log("ProcessAdd", firstNumber, secondNumber);   

            // Validate & Then Convert
            Process(firstNumber, secondNumber);

            // Return Results
            return (_firstNumber + _secondNumber); 

        }


        /// <summary>
        /// Main Division Function
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Division of Input Parameters </returns>
        public async Task<decimal> ProcessDivide(string firstNumber, string secondNumber)
        {
            //Check defined Configuration and do asynchornus logging accordingly  if needed
            await _helper.Log("ProcessDivide", firstNumber, secondNumber);

            // Validate & Then Convert
            Process(firstNumber, secondNumber);  

            if (_firstNumber == 0)
                throw new DivideByZeroException();

            // Return Results
            return (_firstNumber / _secondNumber); 
        }




        /// <summary>
        /// Main Multiply Function
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Multiplication of Input Parameters </returns>
        public async Task<decimal> ProcessMultiply(string num1, string num2)
        {
            //Check defined Configuration and do asynchornus logging accordingly if needed
            await _helper.Log("ProcessMultiply", num1, num2);

            
            // Validate & Then Convert
            Process(num1, num2);

            // Return Results
            return (_firstNumber * _secondNumber); 
        }



        /// <summary>
        /// Main Subtraction Function
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Subtraction of Input Parameters </returns>
        public async Task<decimal> ProcessSubtract(string num1, string num2)
        {
            //Check defined Configuration and do asynchornus logging accordingly if needed
            await _helper.Log("ProcessSubtract", num1, num2);

            // Validate & Then Convert
            Process(num1, num2);

            // Return Results
            return (_firstNumber - _secondNumber); 
        }
    }
}
