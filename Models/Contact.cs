using System.ComponentModel.DataAnnotations;

namespace Garage_Management_System.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }

        [Required, MaxLength(100)]
        public string Names { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone_Number { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
