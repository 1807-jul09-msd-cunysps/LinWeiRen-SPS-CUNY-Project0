namespace ContactLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhoneAppDatabaseContext : DbContext
    {
        public PhoneAppDatabaseContext()
            : base("name=PhoneAppDatabaseContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Person_address> Person_address { get; set; }
        public virtual DbSet<Person_phone> Person_phone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.houseNum)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.address_city)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.address_state)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.address_country)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .Property(e => e.zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Person_address>()
                .HasMany(e => e.People)
                .WithMany(e => e.Person_address)
                .Map(m => m.ToTable("mapped_Person_Address").MapLeftKey("Aid").MapRightKey("Pid"));

            modelBuilder.Entity<Person_phone>()
                .Property(e => e.areaCode)
                .IsUnicode(false);

            modelBuilder.Entity<Person_phone>()
                .Property(e => e.number)
                .IsUnicode(false);

            modelBuilder.Entity<Person_phone>()
                .Property(e => e.ext)
                .IsUnicode(false);
        }
    }
}
