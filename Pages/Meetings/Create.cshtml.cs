using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class CreateModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public CreateModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO
            // Create the Speakers
            var speakers = this.HttpContext.Request.Form["Speaker"];
            var topics = this.HttpContext.Request.Form["Topic"];

            var saved = _context.Meeting.Add(Meeting);

            for (int i = 0; i < speakers.Count; i++)
            {
                Console.WriteLine(speakers[i]);
                Console.WriteLine(topics[i]);

                Speaker speaker = new Speaker();
                speaker.FullName = speakers[i];
                speaker.Topic = topics[i];
                speaker.MeetingID = saved.Entity.ID;
                _context.Speaker.Add(speaker);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
