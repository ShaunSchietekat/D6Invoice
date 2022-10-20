using Microsoft.EntityFrameworkCore;
using D6Invoice.Models;
namespace D6Invoice.Data
{
    public class D6DbContext : DbContext
    {
        public D6DbContext(DbContextOptions<D6DbContext> options) : base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
