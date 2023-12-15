using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Garage_Management_System.Models
{
    public class SellingService
    {
        [Key]
        public int SellingServiceId { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Service { get; set; }

        //[Required]
        //public string Category { get; set; }

        // Assuming this is a string representation of selected tools
        public string Tools { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ToolPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ServiceCharge { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPayment { get; set; }

        public string LabourName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string ClientPhoneNumber { get; set; }
    }

}