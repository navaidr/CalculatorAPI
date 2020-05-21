using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Helpers
{
    public static class Extensions
    {



        /// <summary>
        /// Extension Method to extend the Httpresponse and record erros in Application-Error Header
        /// </summary>
        /// <param name="response">Current Httpresponse object</param>
        /// <param name="message">The Error messsage</param>
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
        

        }

    }
}
