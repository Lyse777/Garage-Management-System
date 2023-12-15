using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using System.Threading.Tasks;

namespace Garage_Management_System.Pages
{
    public class Contact_UsModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public Contact_UsModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact ContactForm { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contact.Add(ContactForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("MessageSuccess");
        }
    }
}
