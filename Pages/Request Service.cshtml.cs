using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Garage_Management_System.Pages
{
    public class RequestServiceModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        [BindProperty]
        public RequestService RequestServiceInfo { get; set; }

        public List<Services> ServicesList { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public RequestServiceModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ServicesList = await _context.Services.ToListAsync();
            RequestServiceInfo = RequestServiceInfo ?? new RequestService();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ServicesList = await _context.Services.ToListAsync();
            ModelState.Remove("RequestServiceInfo.Status");


            if (!ModelState.IsValid)
            {
                ServicesList = await _context.Services.ToListAsync();
                return Page();
            }

            RequestServiceInfo.requested_Date = DateTime.Now; // Set the current date and time
            Debug.WriteLine("Status before save: " + RequestServiceInfo.Status);

            foreach (var entry in ModelState)
            {
                if (entry.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    ErrorMessage += $"Error in {entry.Key}: {string.Join(", ", entry.Value.Errors.Select(e => e.ErrorMessage))}; ";
                }
            }
            try
            {
                // Since the Status column has a default value of 'Pending' in the database,
                // we do not need to set it here.

                var service = await _context.Services
                                            .FirstOrDefaultAsync(s => s.Service_Id == RequestServiceInfo.Service_Id);
                if (service == null)
                {
                    ErrorMessage = "Service not found. Please select a valid service.";
                    ServicesList = await _context.Services.ToListAsync();
                    return Page();
                }
                RequestServiceInfo.Price = service.Price;

                _context.RequestService.Add(RequestServiceInfo);
                await _context.SaveChangesAsync();
                SuccessMessage = "Thank you for Requesting a Service with us. Kindly keep checking your Email for a Response! you will hear from us Soon!!!.";
                // Redirect to a success page or some other page if you want.
                // If you want to stay on the same page, just return Page().
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error occurred: {ex.Message}";
                ServicesList = await _context.Services.ToListAsync();
                return Page();
            }
        }
    }
}