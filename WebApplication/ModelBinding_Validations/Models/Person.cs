using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validations.Models
{
    public class Person
    {
        [Required]
        [RegularExpression("^[A-Za-z .]*$")]
        [StringLength(50,MinimumLength=3)]
        [Display(Name="Name")]
        public string? Name { get; set; }
        [Phone]
        [Required]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Url]
        [ValidateNever] 
        public string? Url { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0,999.99)]
        public int Price { get; set; }

        public override string ToString()  
        {
            return $"phoneNumber: {Phone}, name: {Name}, url: {Url}, Password: {Password}, price: {Price}";

        }
    }
}
