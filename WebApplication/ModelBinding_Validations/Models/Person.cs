using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ModelBinding_Validations.Customvalidations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBinding_Validations.Models
{
    public class Person //:IValidatableObject
    {
        [Required]
        [Display(Name="Name")]
        [RegularExpression("^[A-Za-z .]*$")]
        [StringLength(50,MinimumLength=3)]
      
        public string? Name { get; set; }
        [Phone]
        //[Required]
        public string? Phone { get; set; }
       // [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Url]
        [ValidateNever] 
        public string? Url { get; set; }
       // [Required]
        public string? Password { get; set; }
       // [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0,999.99)]
        public int Price { get; set; }
        //[MinimumYearValidater(ErrorMessage ="Not Alowed the minimum year is 2000")]
        // [MinimumYearValidater(ErrorMessage ="Not Alowed the minimum year is {0}")]//"Not Alowed the minimum year is 2002"
        [MinimumYearValidater(2002)]//"Not alwoed to be less than 2002" DefaultErrorMessge
        [BindNever]
        public DateTime? DateOfBirth { get; set; }
        public DateTime FromDate { get; set; }
        [DateRangeValidator("FromDate")]
        public DateTime ToDate { get; set; }
        [BindNever]
        public int? Age { get; set; }
        public override string ToString()  
        {
            return $"phoneNumber: {Phone}, name: {Name}, url: {Url}, Password: {Password}, price: {Price}";

        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //   if(!DateOfBirth.HasValue&& !Age.HasValue)
        //        yield return new ValidationResult ("not Alowed to be both Age and Date of birth null.");
        //  // if(!Age.HasValue)
        //  //      yield return new ValidationResult("Error22..."); // the output with yield will be -->   "Error...", "Error22...",
        //}
    }
}
