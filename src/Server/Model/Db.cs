using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Epam.Password.Server.Model
{
    // if something changes
    // Add-Migration %NAME% -Environment Developer
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
