using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;


namespace Garage_Management_System.Pages.Manager.InventoryManage
{
    public class CreateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public CreateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inventory.Add(Inventory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

