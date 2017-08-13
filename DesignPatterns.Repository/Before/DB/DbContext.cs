using System.Data.Entity;

namespace DesignPatterns.Repository.Before.DB
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Fruit> Fruits => Set<Fruit>();
    }
}
