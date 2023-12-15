using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_Management_System.Models
{
    public class RequestService
    {
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Names { get; set; }

        [Required(ErrorMessage = "The Service field is required.")]
        public int Service_Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone_Number { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public decimal Price { get; set; }
        public string Status { get; set; } // No [Required] attribute means this field is not required from the form.
        public DateTime requested_Date { get; set; }
    }
}
