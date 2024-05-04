using System.Data.Entity;

public class _DbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderMaster> OrderMasters { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
}
