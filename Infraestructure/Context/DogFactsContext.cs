using Domain.DogFacts.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class DogFactsContext : DbContext
    {
        public DogFactsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DogFactsEntity> DogFacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<DogFactsEntity>().HasData(new DogFactsEntity(Guid.Parse("c7e8ab41-b156-498f-b49e-be62f919c39c"),"bad", "Stronger", DateTime.UtcNow));
            base.OnModelCreating(modelBuilder);
        }
    }
}
