using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Pages.Manager.LaboursManage
{
    public class IndexModel : PageModel
    {
        private readonly HC_Garage_DbContext _context;

        public IndexModel(HC_Garage_DbContext context)
        {
            _context = context;
        }

        public IList<Labour> Labours { get; set; }

        public async Task OnGetAsync()
        {
            Labours = await _context.Labours.ToListAsync();
        }
    }
}
