using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {
        }
        public DbSet<Game> Games { get; set; }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}
