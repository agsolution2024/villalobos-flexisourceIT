using Microsoft.EntityFrameworkCore;
using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Infrastructure.DBContext
{
    public class RunningActivityDB : DbContext
    {
        public RunningActivityDB(DbContextOptions<RunningActivityDB> options) : base(options) { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Activities> Activities { get; set; }

    }
}


