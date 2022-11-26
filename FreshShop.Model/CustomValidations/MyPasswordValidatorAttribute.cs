using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.CustomValidations
{
    public class MyPasswordValidatorAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value != null ? value.ToString() : "";

            string lower = "abcdefghijklmnoprstuvyz";
            string digits = "0123456789";

            bool isValidForLower = false;
            bool isValidForDigit = false;

            for (int i = 0; i < password.Length; i++)
            {
                if(lower.Contains(password[i]))
                {
                    isValidForLower = true;
                }

                if (digits.Contains(password[i]))
                {
                    isValidForDigit = true;
                }

            }

            if (isValidForLower && isValidForDigit)
                return true;

            return false;

        }
    }
}
