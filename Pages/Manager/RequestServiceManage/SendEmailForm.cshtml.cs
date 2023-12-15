using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Interfaces;
using System.Threading.Tasks;


namespace Garage_Management_System.Pages.Manager.RequestServiceManage
{
    public class SendEmailFormModel : PageModel
    {
        private readonly IEmailService _emailService;

        public SendEmailFormModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public int ServiceRequestId { get; set; }
        [BindProperty]
        public string ToEmail { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Body { get; set; }

        public void OnGet(int requestId)
        {
            ServiceRequestId = requestId;
            // You can pre-fill some fields if you want, based on the request ID
        }

        public int RequestId { get; set; } // Add this property

        public async Task<IActionResult> OnPostAsync()
        {
            await _emailService.SendEmailAsync(ToEmail, Subject, Body);

            TempData["EmailSent"] = "True";

            return RedirectToPage("SendEmailForm", new { requestId = ServiceRequestId });

        }
    }
}
