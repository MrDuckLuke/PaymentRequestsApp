using Microsoft.EntityFrameworkCore;
using PaymentRequestsApp.Models;

namespace PaymentRequestsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        public DbSet<PaymentRequest> PaymentRequests => Set<PaymentRequest>();

    }
}
