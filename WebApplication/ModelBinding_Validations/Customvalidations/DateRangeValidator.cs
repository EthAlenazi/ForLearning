using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBinding_Validations.Customvalidations
{
    public class DateRangeValidator: ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidator( string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) { 
                //get to date 
                DateTime to_date = (DateTime)value;

                //get from date
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherProperty != null)
                {
                    DateTime from_date = 
                    Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (from_date>to_date)
                    {
                        return new ValidationResult(ErrorMessage,
                            new string[] {
                                OtherPropertyName
                            });
                    }
                    return ValidationResult.Success;
                }
                return null;
            }
            return null;
        }
    }
}
