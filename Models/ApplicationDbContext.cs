using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace RagilHadiworoApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Funding> Fundings { get; set; }
        public DbSet<Agunan> Agunans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LendingCustomerRelation());
            modelBuilder.ApplyConfiguration(new FundingCustomerRelation());
            modelBuilder.ApplyConfiguration(new AgunanCustomerRelation());
            base.OnModelCreating(modelBuilder);
        }

        public class LendingCustomerRelation : IEntityTypeConfiguration<Lending>
        {
            public void Configure(EntityTypeBuilder<Lending> builder)
            {
                builder.HasOne(e => e.Customer)
                       .WithMany(f => f.Lendings)
                       .HasForeignKey(e => e.IDCustomer)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
        public class FundingCustomerRelation : IEntityTypeConfiguration<Funding>
        {
            public void Configure(EntityTypeBuilder<Funding> builder)
            {
                builder.HasOne(e => e.Customer)
                       .WithMany(f => f.Fundings)
                       .HasForeignKey(e => e.IDCustomer)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
        public sealed class AgunanCustomerRelation : IEntityTypeConfiguration<Agunan>
        {
            public void Configure(EntityTypeBuilder<Agunan> builder)
            {
                builder.HasOne(e => e.Customer)
                       .WithMany(f => f.Agunans)
                       .HasForeignKey(e => e.IDCustomer)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }

    
}
