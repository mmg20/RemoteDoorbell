using Microsoft.EntityFrameworkCore;

namespace RemoteDoorbell.Model
{
    public class DoorbellContext : DbContext
    {
        public DbSet<RingEntry> RingEntries { get; set; }

        public DoorbellContext(DbContextOptions<DoorbellContext> opts)
            : base(opts)
        {
        }
    }
}
