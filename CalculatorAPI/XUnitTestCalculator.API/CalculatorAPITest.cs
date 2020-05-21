using System;
using Xunit;
using Calculator.API.Controllers;
using Calculator.API.BLL;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Calculator.API.Logging;

namespace XUnitTestCalculator.API
{
    public class CalculatorAPITest
    {

        #region DataMembers
        CalculateController _controller;
        IOperations _operations;
        IConfiguration _configuration;
        ILogging _logging;

        #region Private Members
        private string _firstNumber;
        private string _secondNumber;
        #endregion


        #endregion

        #region Initializers
        public CalculatorAPITest()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

          
            _logging = new FileLogging(_configuration);
            _operations = new Operations(_configuration, _logging);
             _controller = new CalculateController(_operations,_configuration);

            LoadTestData();
        }

        #endregion

        #region Input Data Function
        void LoadTestData()
        {
            _firstNumber = "1";
            _secondNumber = "1.6";
        }

        #endregion

        #region Http 200/Ok Test Cases For All Api Calls
        [Fact]
        public void Add_WhenCalled_OkResult()
        {
            //Act
            var OkResponse = _controller.Add(_firstNumber, _secondNumber);
            //Assert
           Assert.IsType<OkObjectResult>(OkResponse.Result);
        }
        
        [Fact]
        public void Subtract_WhenCalled_OkResult()
        {
            //Act
            var OkResponse = _controller.Subtract(_firstNumber, _secondNumber);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }


        [Fact]
        public void Multiply_WhenCalled_OkResult()
        {
            //Act
            var OkResponse = _controller.Multiply(_firstNumber, _secondNumber);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);
        }


        [Fact]
        public void Divide_WhenCalled_OkResult()
        {
            //Act
            var OkResponse = _controller.Divide(_firstNumber, _secondNumber);

            //Assert
            Assert.IsType<OkObjectResult>(OkResponse.Result);


        }

        #endregion

        #region Functional/Business Test Cases
        [Fact]
        public void Add_WhenCalled_ValidResult()
        {
            string firstNumber = "1";
            string secondNumber = "2";
            
            //Act
            string response = ((ObjectResult)_controller.Add(firstNumber, secondNumber).Result).Value.ToString().Split('=')[1].Replace("}","").Trim();

            decimal expected = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber); 

            Assert.Equal(expected, Convert.ToDecimal(response));


        }

        [Fact]
        public void Subtract_WhenCalled_ValidResult()
        {
            string firstNumber = "1";
            string secondNumber = "2";

            //Act
            string response = ((ObjectResult)_controller.Subtract(firstNumber, secondNumber).Result).Value.ToString().Split('=')[1].Replace("}", "").Trim();

            decimal expected = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);

            //Assert
            Assert.Equal(expected, Convert.ToDecimal(response));


        }


        [Fact]
        public void Divide_WhenCalled_ValidResult()
        {
            string firstNumber = "1";
            string secondNumber = "2";

            //Act
            string response = ((ObjectResult)_controller.Divide(firstNumber, secondNumber).Result).Value.ToString().Split('=')[1].Replace("}", "").Trim();

            decimal expected = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);

            //Assert
            Assert.Equal(expected, Convert.ToDecimal(response));


        }


        [Fact]
        public void Multiply_WhenCalled_ValidResult()
        {
            string firstNumber = "1";
            string secondNumber = "2";

            //Act
            string response = ((ObjectResult)_controller.Multiply(firstNumber, secondNumber).Result).Value.ToString().Split('=')[1].Replace("}", "").Trim();

            decimal expected = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);

            //Assert
            Assert.Equal(expected, Convert.ToDecimal(response));


        }
        #endregion

    }
}
