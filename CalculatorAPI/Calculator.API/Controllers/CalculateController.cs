using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.API.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Calculator.API.Helpers;


namespace Calculator.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        private readonly IOperations _Operations;
        private readonly IConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="config"></param>
        public CalculateController(IOperations operations, IConfiguration config)
        {
            _Operations = operations;
            _config = config;
        }

        /// <summary>
        /// Main Addition Controller
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the addition of Input Parameters </returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(string firstNumber, string secondNumber)
        {
            return Ok(new { result = await _Operations.ProcessAdd(firstNumber, secondNumber) });
        }



        /// <summary>
        /// Main Subtraction Controller
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Subtraction of Input Parameters </returns>
        [HttpPost("Subtract")]
        public async Task<IActionResult> Subtract(string firstNumber, string secondNumber)
        {
            return Ok(new { result = await _Operations.ProcessSubtract(firstNumber, secondNumber) });
        }

        /// <summary>
        /// Main Multiply Controller
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Multiplication of Input Parameters </returns>
        [HttpPost("Multiply")]
        public async Task<IActionResult> Multiply(string firstNumber, string secondNumber)
        {
            return Ok(new { result = await _Operations.ProcessMultiply(firstNumber, secondNumber) });
        }


        /// <summary>
        /// Main Division Controller
        /// </summary>
        /// <param name="firstNumber">Input Parameter 1 </param>
        /// <param name="secondNumber">Input Parameter 2</param>
        /// <returns>Returns the Division of Input Parameters </returns>
        [HttpPost("Divide")]
        public async Task<IActionResult> Divide(string firstNumber, string secondNumber)
        {
            return Ok(new { result = await _Operations.ProcessDivide(firstNumber, secondNumber) });
        }
    }
}