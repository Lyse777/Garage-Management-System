using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Pages.Manager.ServicesManage
{
    public class UpdateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public UpdateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Services Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Service = await _context.Services.FirstOrDefaultAsync(m => m.Service_Id == id);

            if (Service == null)
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

            _context.Attach(Service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(Service.Service_Id))
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

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Service_Id == id);
        }
    }
}

