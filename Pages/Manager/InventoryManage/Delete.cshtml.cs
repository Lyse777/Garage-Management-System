using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;

namespace Garage_Management_System.Pages.Manager.InventoryManage
{
    public class DeleteModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public DeleteModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Inventory = await _context.Inventory.FindAsync(id);

            if (Inventory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var inventoryItem = await _context.Inventory.FindAsync(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}