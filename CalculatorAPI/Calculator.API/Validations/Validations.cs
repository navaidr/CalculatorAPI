using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.API.Helpers;


    public class Validations : IValidate
    {

        public virtual bool Validate(string num1,string num2)
        {

          
              
              if (!Helper.IsNumber(num1))
                throw new Exception("Error: input 1 is not a number");

            if (!Helper.IsNumber(num2))
                throw new Exception("Error: input 2 is not a number");


            return true;
         }
               
     }

