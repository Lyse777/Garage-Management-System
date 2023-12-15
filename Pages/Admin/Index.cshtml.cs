using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;

namespace Garage_Management_System.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public IndexModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }

}
