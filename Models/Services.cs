using System.ComponentModel.DataAnnotations;

namespace Garage_Management_System.Models
{
    public class Services
    {

        [Key]
        public int Service_Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        [StringLength(100)]
        public string Service_Name { get; set; }
        [StringLength(100)]
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}

