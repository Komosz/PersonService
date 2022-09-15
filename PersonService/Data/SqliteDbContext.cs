using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PersonService.Data
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public SqliteDbContext() => SqliteInitialize();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=sqlitedb", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons", "test");
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(k => k.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
        
        private void SqliteInitialize()
        {
            var dbName = "sqlitedb";
            if (File.Exists(dbName))
                return;
                //File.Delete(dbName);

            Database.EnsureCreated();

            Persons.AddRange(new Person[]{
                new Person(){ ApartmentNumber = "TEST1", DateOfBirth = DateTime.Now.AddYears(-1).AddDays(1), FirstName = "IMIE", HouseNumber = "TEST1", LastName = "NAZWISKO", PhoneNumber = "123", PostalCode = "82-200", StreetName = "TEST1", Town = "TEST1"},
                new Person(){ ApartmentNumber = "TEST2", DateOfBirth = DateTime.Now.AddYears(-1).AddDays(-1), FirstName = "IMIE", HouseNumber = "TEST2", LastName = "NAZWISKO", PhoneNumber = "123", PostalCode = "82-200", StreetName = "TEST2", Town = "TEST2"}
            });
            SaveChanges();
        }
    }
}
