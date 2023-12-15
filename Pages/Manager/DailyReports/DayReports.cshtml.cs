using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Garage_Management_System.Models;

namespace Garage_Management_System.Pages.Manager.DailyReports
{
    public class DayReportsModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;


        public DayReportsModel(HC_Garage_DbContext context)
        {
            _context = context;
            dataAccess = new SellingService(); // Initialize dataAccess
        }


        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; } = DateTime.Today;


        public int counter { get; set; } // Ensure this is public
        public SellingService dataAccess { get; set; } // Ensure this is public
        public string errorMessage { get; set; } // Ensure this is public


        public void OnGet()
        {
            SellingSummary(SelectedDate);
        }

        public void SellingSummary(DateTime selectedDate)
        {
            try
            {
                var sellingServices = _context.SellingServices
                    .Where(ss => ss.Date.Date == selectedDate.Date)
                    .Select(ss => new { ss.TotalAmount, ss.ServiceCharge, ss.TotalPayment })
                    .ToList();

                counter = sellingServices.Count;

                if (counter > 0) // Check if there are any records
                {
                    dataAccess.TotalAmount = sellingServices.Sum(ss => ss.TotalAmount);
                    dataAccess.ServiceCharge = sellingServices.Sum(ss => ss.ServiceCharge);
                    dataAccess.TotalPayment = sellingServices.Sum(ss => ss.TotalPayment);
                }
                else
                {
                    // Reset the values if no records are found
                    dataAccess.TotalAmount = 0;
                    dataAccess.ServiceCharge = 0;
                    dataAccess.TotalPayment = 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}