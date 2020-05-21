using Calculator.API.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Calculator.API.Logging
{
    /// <summary>
    /// The purpose of this class is to log the information in Text file.
    /// </summary>
    public class FileLogging : ILogging
    {
        

        #region DataMembers

        #region Private DataMembers

        private readonly string _logfilename;
        private string _logpath;

        #endregion

        #endregion

        #region enums
        public enum LogType
        {
            ERROR,
            WARNING,
            INFO
        }

        #endregion


        #region Initliazers
        public FileLogging(IConfiguration config)
        {

            _logfilename = config.GetSection(AppConstants.LogFileName).Value;
            _logpath = config.GetSection(AppConstants.LogFilePath).Value;
        }
        #endregion


        #region Functions

        /// <summary>
        /// This Method Writes the Input Paramters in logs with action name
        /// </summary>
        /// <param name="actionname"></param>
        /// <param name="input1"> Input # 1</param>
        /// <param name="input2"> Input # 2</param>
        /// <returns></returns>
        public async Task WriteInfoLog(string actionname, string input1, string input2)
        {
            await write(actionname, LogType.INFO, "Input1:" + input1 + " Input2: " + input2);
        }



        //Not Implemented
        public Task WriteErrorLog(string actionname, string input1, string input2)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Main Function to write the logs in the file
        /// </summary>
        /// <param name="action">Controller Name</param>
        /// <param name="logType">Type of Log i.e. Info, Error etc</param>
        /// <param name="description">Description of the text</param>
        /// <returns></returns>
        async Task write(string action, LogType logType, string description)
        {
            FileStream fs = null;
            StreamWriter strWriter = null;
            try
            {
                if (!Directory.Exists(_logpath))
                    Directory.CreateDirectory(_logpath);

                _logpath = String.Format(@"{0}\{1}-{2}.txt", _logpath, _logfilename, DateTime.Now.ToString("ddMMMyyyy"));
                fs = new FileStream(_logpath, FileMode.Append, FileAccess.Write);
                strWriter = new StreamWriter(fs);
                strWriter.BaseStream.Seek(0, SeekOrigin.End);
                await strWriter.WriteLineAsync("[" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss:fff") + "]: " + "Action: " + action + " -  Data: " + description);
             
            }
            catch
            {
                throw;
            }
            finally
            {

                strWriter.Close();
                strWriter.Dispose();
         
                fs.Close();
                fs.Dispose();
             
                
            }
        }

        #endregion
    }
}
