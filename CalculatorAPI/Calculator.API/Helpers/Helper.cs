using Calculator.API.Configuration;
using Calculator.API.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;



namespace Calculator.API.Helpers
{
    public class Helper
    {

        #region DataMembers
        private Dictionary<string, string> _loggingconfiguration { get; set; }


        #region Private DataMembers
        private readonly IConfiguration _config;
        private readonly ILogging _logging;
        #endregion

        #endregion

        #region Initializers
        public Helper(IConfiguration config, ILogging logging)
        {
            _config = config;
            _logging = logging;
            LoadConfiguration();
        }

        #endregion

        #region Functions

        /// <summary>
        /// This function check the given input whether its number or not
        /// </summary>
        /// <param name="num">input string</param>
        /// <returns></returns>
        public static bool IsNumber(string num)
        {
            decimal value;
            if (!Decimal.TryParse(num, out value))
                return false;
            else
                return true;
        }

        /// <summary>
        /// This Function loads Configuration Settings from appsettings.json file OR 
        /// from DB without code change and just reading the value from appsettings.json file
        /// </summary>
        private void LoadConfiguration()
        {
           string value= _config.GetSection(AppConstants.LoadConfiguration).Value;

            if (value.Equals("FromConfig")) 
            {
                // Load Configuration From appsettings.json
                ConfigHelper config = new ConfigHelper(_config); 
                _loggingconfiguration = config.GetConfig();
            }

            if (value.Equals("FromDb"))
            {
                // Load Configuration From DB Just for demonstration ** Not Implemented**
                DbConfigHelper config = new DbConfigHelper(_config); 
                _loggingconfiguration = config.GetConfig();
            }

        }

        /// <summary>
        /// Main Logging Function
        /// </summary>
        /// <param name="actionname">Controller's Name</param>
        /// <param name="firstNumber">Input Parameter 1 to log</param>
        /// <param name="secondNumber">Input Parameter 2 to log</param>
        /// <returns></returns>
        public async Task Log(string actionname,string firstNumber, string secondNumber)
        {

            //if particular Action is configured to Log the details
            if (_loggingconfiguration[actionname].ToUpper().Trim() == "Y")

                //Writes Appropriate Log asynchronously either in TextFile or DB depending upon defined configuration.
                await _logging.WriteInfoLog(actionname, firstNumber, secondNumber); 
        }

        #endregion
    }
}
