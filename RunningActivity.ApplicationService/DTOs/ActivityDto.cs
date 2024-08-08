using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Infrastructure.Model
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public double AveragePace => Duration.TotalMinutes / Distance;
        public int UserProfileId { get; set; }

    }
}
