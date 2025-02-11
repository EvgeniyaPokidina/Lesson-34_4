using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_34_4
{
    public class UserDBContext:DbContext
    {
      
        private StreamWriter infoLog = new StreamWriter("infoLog.log", true);
        private StreamWriter warningLog = new StreamWriter("warningLog.log", true);
        private StreamWriter criticalLog = new StreamWriter("criticalLog.log", true);
        public UserDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> People { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(infoLog.WriteLine, LogLevel.Information);
            optionsBuilder.LogTo(warningLog.WriteLine, LogLevel.Warning);
            optionsBuilder.LogTo(criticalLog.WriteLine, LogLevel.Critical);
        }
        public override void Dispose()
        {
            base.Dispose();
            infoLog.Dispose();
            warningLog.Dispose();
            criticalLog.Dispose();
        }

    }
}
