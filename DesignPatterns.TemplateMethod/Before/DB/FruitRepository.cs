using System;
using System.Data.Entity;
using System.Linq;

namespace DesignPatterns.TemplateMethod.Before.DB
{
    public class FruitRepository : IDisposable
    {
        private readonly DbContext _dbContext;
        private readonly IQueryable<Fruit> _notTrackedQueriableEntities;

        public FruitRepository()
        {
            _dbContext = new DbContext();
            _notTrackedQueriableEntities = _dbContext.Fruits.AsNoTracking();
        }

        public void Add(Fruit entity)
        {
            _dbContext.Fruits.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Upate(Fruit entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Remove(Fruit entity)
        {
            _dbContext.Fruits.Attach(entity);
            _dbContext.Fruits.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Fruit Find(int id)
        {
            var entity = _notTrackedQueriableEntities.SingleOrDefault(a => a.Id == id);
            return entity;
        }

        public IQueryable<Fruit> GetAll() => _notTrackedQueriableEntities;

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
