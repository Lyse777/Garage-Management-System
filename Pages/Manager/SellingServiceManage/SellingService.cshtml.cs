using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic; // Make sure to include this for List<>
using Microsoft.EntityFrameworkCore;


namespace Garage_Management_System.Pages.Manager.SellingServiceManage
{
    public class SellingServiceModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public SellingServiceModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SellingService sellingServiceInfo { get; set; }
        public List<SellingService> sellingServicesList = new List<SellingService>();
        public List<Services> ServicesLists = new List<Services>(); // Assuming Service is the correct entity name
        public List<Inventory> InventoryList = new List<Inventory>();
        public List<Labour> laboursList = new List<Labour>();

        public string errorMessage = "";
        public string successMessage = "";
        public List<string> validationErrors = new List<string>(); // To collect validation errors

        public async Task OnGetAsync()
        {
            sellingServicesList = await _context.SellingServices.ToListAsync();
            ServicesLists = await _context.Services.ToListAsync();
            InventoryList = await _context.Inventory.ToListAsync();
            laboursList = await _context.Labours.ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Log and display validation errors
                // ...
                await InitializeDataAsync(); // Load existing data to display
                return Page();
            }

            try
            {
                // Save the new selling service
                sellingServiceInfo.Date = DateTime.UtcNow; // Set the date if not set by the form
                _context.SellingServices.Add(sellingServiceInfo);
                await _context.SaveChangesAsync();
                successMessage = "Service has been recorded successfully.";

                // Reload the data to include the new selling service
                await InitializeDataAsync(); // Reload the list with updated data
                return Page(); // Refresh the page with new data
            }
            catch (Exception ex)
            {
                // Log exception and return with error message
                // ...
                await InitializeDataAsync(); // Load existing data to display even in case of error
                return Page();
            }
        }


        private async Task InitializeDataAsync()
        {
            sellingServicesList = await _context.SellingServices.ToListAsync();
            ServicesLists = await _context.Services.ToListAsync(); // Assuming Services is the correct entity name
            InventoryList = await _context.Inventory.ToListAsync(); // Make sure Inventory is the correct entity name
            laboursList = await _context.Labours.ToListAsync(); // Assuming Labours is the correct entity name
        }
    }
}
