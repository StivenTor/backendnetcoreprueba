using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaNetCore.Model
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext() { 
        
        }
        

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql("server=127.0.0.1;user id=root;password=;port=3306;database=pruebanetcore;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.Cellphone).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }

        public List<Person> getPersons() => Persons.ToList();
    }
}
