using System.Data.Entity;

namespace DesignPatterns.TemplateMethod.After.DB
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Fruit> Fruits => Set<Fruit>();
    }
}
