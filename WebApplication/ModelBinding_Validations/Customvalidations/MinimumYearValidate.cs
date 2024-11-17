using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validations.Customvalidations
{
    public class MinimumYearValidater:ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessge = "Not alwoed to be less than {0}";
        public MinimumYearValidater()
        {
            
        }
        public MinimumYearValidater(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear) {
                    return new ValidationResult(string.Format( ErrorMessage?? DefaultErrorMessge,MinimumYear));

                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
