using System.Data.Entity;
using Vidly.Models;

namespace Vidly.DAL
{
    public class VidlyContext : DbContext
    {
        public VidlyContext() : base("DefaultConnection")
        {

        }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}