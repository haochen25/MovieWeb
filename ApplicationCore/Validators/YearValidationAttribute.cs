using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Validators
{
    public class YearValidationAttribute : ValidationAttribute

    { int _minYear;
        int _maxYear;
        public YearValidationAttribute(int minYear, int maxYear)
        {
            _minYear = minYear;
            _maxYear = maxYear;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int year;
                bool isInteger = int.TryParse(value.ToString(), out year);
                if (isInteger)
                {
                    if (year >= _minYear && year <= _maxYear)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult($"Year must be between {_minYear} and {_maxYear}");
                    }
                }
                else
                {
                    return new ValidationResult("Invalid year format");
                }
            }
            return new ValidationResult("Year is required");
        }
    }
}
