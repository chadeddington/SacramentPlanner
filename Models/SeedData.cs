using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentPlannerContext>>()))
            {
                if (context.Meeting.Any())
                { 
                    return;
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        Date = DateTime.Parse("2020-2-12"),
                        Conductor = "Bishop Bart",
                        OpeningPrayer = "Sister Solliliqy",
                        OpeningHymn = 100,
                        SacramentHymn = 101,
                        IntermediateHymn = "Sister Slosh's Singing",
                        ClosingHymn = 25,
                        ClosingPrayer = "Brother Beowulf"

                    },
                    new Meeting
                    {
                        Date = DateTime.Parse("2020-3-15"),
                        Conductor = "1st Counsler Conrad",
                        OpeningPrayer = "Sister Savage",
                        OpeningHymn = 58,
                        SacramentHymn = 26,
                        ClosingHymn = 254,
                        ClosingPrayer = "Brother Beacon"
                    },
                    new Meeting
                    {
                        Date = DateTime.Parse("2020-4-22"),
                        Conductor = "Stake President Peterson",
                        OpeningPrayer = "Brother Bale",
                        OpeningHymn = 98,
                        SacramentHymn = 211,
                        ClosingHymn = 184,
                        ClosingPrayer = "Sister Solar"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
