using collection_control_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api
{
    public class CollectionContext : DbContext
    {
        public CollectionContext(DbContextOptions<CollectionContext> options) : base(options) { }

        public DbSet<Item> items { get; set; }
        public DbSet<Dvd> dvds { get; set; }
        public DbSet<Cd> cds { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Client> clients { get; set; }
    }
}
