using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public IndexModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meetings { get;set; }

        public async Task OnGetAsync()
        {
            //Meetings = await _context.Meeting.ToListAsync();

            //var speakers = from s in _context.Speaker
            //             select s;

            //var meetings = from m in _context.Meeting
            //               select m;

            var meetings = _context.Meeting.Include(m => m.Speakers);


            Meetings = await meetings.ToListAsync();
        }
    }
}
