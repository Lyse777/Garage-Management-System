using System.ComponentModel.DataAnnotations;

namespace Garage_Management_System.Models
{
    public class Labour
    {

        [Key]
        public int LabourId { get; set; }

        [Required, MaxLength(100)]
        public string LabourName { get; set; }

        [Required, MaxLength(50)]
        public string Gender { get; set; }

        [Required, MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }
    }


}
