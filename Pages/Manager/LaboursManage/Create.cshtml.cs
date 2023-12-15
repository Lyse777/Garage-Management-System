using Garage_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garage_Management_System.Pages.Manager.LaboursManage
{
    public class CreateModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public CreateModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Labour Labour { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Labours.Add(Labour);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
