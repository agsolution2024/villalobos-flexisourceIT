using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Infrastructure.Model
{
    public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age => DateTime.Now.Year - BirthDate.Year;
    public double BMI => Weight / ((Height / 100) * (Height / 100));
    public ICollection<Activities> Activities { get; set; }
}
}
