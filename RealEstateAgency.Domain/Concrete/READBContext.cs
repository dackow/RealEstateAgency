using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Concrete
{
    public class READBContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }
    }
}
