using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Context
{
	public class CoreDbContext : DbContext
	{
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
         : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
	}
}
