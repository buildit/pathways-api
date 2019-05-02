using Microsoft.EntityFrameworkCore;
using pathways_api.Data.Entities;

namespace pathways_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
    }
}