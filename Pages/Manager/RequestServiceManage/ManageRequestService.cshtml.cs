using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Garage_Management_System.Pages.Manager
{
    public class ManageRequestServiceModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public List<RequestService> RequestServices { get; set; }

        public ManageRequestServiceModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            RequestServices = await _context.RequestService.ToListAsync();
        }

        public async Task OnPostAsync(int id, string status)
        {
            var serviceRequest = await _context.RequestService.FindAsync(id);
            if (serviceRequest != null)
            {
                serviceRequest.Status = status;
                await _context.SaveChangesAsync();
            }

            RequestServices = await _context.RequestService.ToListAsync();
        }



        public async Task<IActionResult> OnPostEmailAsync(int id)
        {
            var request = await _context.RequestService.FindAsync(id);
            if (request != null)
            {
                // Assuming you have a form to collect email details
                // Redirect to the form page with the request ID
                return RedirectToPage("SendEmailForm", new { requestId = id });
            }

            return RedirectToPage();
        }
    }
}