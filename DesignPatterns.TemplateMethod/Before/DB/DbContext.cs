using System.Data.Entity;

namespace DesignPatterns.TemplateMethod.Before.DB
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Fruit> Fruits => Set<Fruit>();
    }
}
