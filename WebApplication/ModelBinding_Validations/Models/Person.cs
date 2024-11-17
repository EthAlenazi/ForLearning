using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validations.Models
{
    public class Person
    {
        [Required]
        public string? phoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public int Price { get; set; }
    }
}
