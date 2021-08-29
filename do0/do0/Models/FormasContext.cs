using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using do0.Models;
//using do0.Migrations;

namespace do0.Models
{
    public class FormasContext : DbContext
    {
        public FormasContext()
            : base("FormasContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FormasContext, Configuration>());
            Database.SetInitializer<FormasContext>(new DropCreateDatabaseIfModelChanges<FormasContext>());
            //Database.SetInitializer<FormasContext>(new DropCreateDatabaseAlways<FormasContext>());
            //Database.SetInitializer<FormasContext>(new DropCreateDatabaseIfModelChanges<FormasContext>());
            //Database.SetInitializer<FormasContext>(new DropCreateDatabaseAlways<FormasContext>());
            //Database.SetInitializer<FormasContext>(new do0DbInicializador());
        }

        public DbSet<Diretorio> Diretorios { get; set; }
        public DbSet<Formas> Formas { get; set; }

    }
}