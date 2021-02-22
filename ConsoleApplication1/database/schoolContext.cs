using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.database
{
    public class schoolContext:DbContext
    {
        public schoolContext() : base("school")
        {
            Database.SetInitializer<DbContext>(new CreateDatabaseIfNotExists<DbContext>());
            Database.Initialize(true);
            
        }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<classroom> classroom { get; set; }
        public DbSet<Students> Students { get; set; }
    }
}
