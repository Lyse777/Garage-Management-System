using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;


namespace Garage_Management_System.Pages.Manager.InventoryManage
{
    public class UpdateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public UpdateModel(HC_Garage_DbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(Inventory.InventoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryId == id);
        }
    }
}
