﻿namespace school_Management.Migrations
{
    using school_Management.database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<school_Management.database.schoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(school_Management.database.schoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.classroom.AddOrUpdate(
             p => p.Name,
                  new classroom { Name = "شهید دست غیب" },
                  new classroom { Name = "شهید باکری " },
                  new classroom { Name = "شهید چمران" },
                  new classroom { Name = "امام خمینی" },
                  new classroom { Name = "شهید همت" },
                  new classroom { Name = "شهید حق گو" }
            );

        }
    }
}
