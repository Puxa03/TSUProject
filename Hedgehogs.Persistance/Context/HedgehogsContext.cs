using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hedgehogs.Persistance.Context
{
    public class HedgehogsContext:DbContext
    {
        public HedgehogsContext(DbContextOptions<HedgehogsContext> opts):base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HedgehogsContext).Assembly);
        }

    }
}
