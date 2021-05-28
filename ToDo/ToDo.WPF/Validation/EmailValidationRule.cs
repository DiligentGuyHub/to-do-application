using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDo.WPF.Validation
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(string.IsNullOrEmpty((string)(value)))
            {
                return new ValidationResult(false, "empty email");
            }

            Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");

            if(!regex.Match((string)(value)).Success)
            {
                return new ValidationResult(false, "empty email");
            }

            return ValidationResult.ValidResult;
        }
    }
}
