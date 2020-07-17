using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Meetings
{
    public class EditModel : PageModel
    {
        private readonly SacramentPlanner.Data.SacramentPlannerContext _context;

        public EditModel(SacramentPlanner.Data.SacramentPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meeting.Include(m => m.Speakers).FirstOrDefaultAsync(m => m.ID == id);

            if (Meeting == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meeting).State = EntityState.Modified;

            var existingSpeakers = this.HttpContext.Request.Form["ExistingSpeaker"];
            var existingTopics = this.HttpContext.Request.Form["ExistingTopic"];
            var speakerIDs = this.HttpContext.Request.Form["SpeakerID"];

            for (int i = 0; i < existingSpeakers.Count; i++)
            {
                Speaker speaker = new Speaker();
                speaker.ID = Int32.Parse(speakerIDs[i]);

                if (existingSpeakers[i].Length == 0)
                {
                    _context.Speaker.Remove(speaker);
                } else
                {
                    speaker.FullName = existingSpeakers[i];
                    speaker.Topic = existingTopics[i];
                    speaker.MeetingID = Meeting.ID;
                    _context.Attach(speaker).State = EntityState.Modified;
                }          
            }

            var newSpeakers = this.HttpContext.Request.Form["Speaker"];
            var newTopics = this.HttpContext.Request.Form["Topic"];

            if (newSpeakers.Count > 0)
            {
                for (int i = 0; i < newSpeakers.Count; i++)
                {
                    Speaker speaker = new Speaker();
                    speaker.FullName = newSpeakers[i];
                    speaker.Topic = newTopics[i];
                    speaker.MeetingID = Meeting.ID;
                    _context.Speaker.Add(speaker);
                }
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(Meeting.ID))
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

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
