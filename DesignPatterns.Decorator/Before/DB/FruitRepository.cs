using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DesignPatterns.Decorator.Before.DB
{
    public class FruitRepository : IFruitRepository
    {
        private readonly DbContext _dbContext;
        private readonly IQueryable<Fruit> _notTrackedQueriableEntities;
        private readonly Dictionary<int, Fruit> _cache;

        public FruitRepository()
        {
            _dbContext = new DbContext();
            _notTrackedQueriableEntities = _dbContext.Fruits.AsNoTracking();
            _cache = new Dictionary<int, Fruit>();
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

            if (_cache.ContainsKey(entity.Id))
            {
                _cache[entity.Id] = entity;
            }
        }

        public void Remove(Fruit entity)
        {
            _dbContext.Fruits.Attach(entity);
            _dbContext.Fruits.Remove(entity);
            _dbContext.SaveChanges();

            _cache.Remove(entity.Id);
        }

        public Fruit Find(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            var entity = _notTrackedQueriableEntities.SingleOrDefault(a => a.Id == id);
            if (entity != null)
            {
                _cache[id] = entity;
            }

            return entity;
        }

        public IQueryable<Fruit> GetAll() => _notTrackedQueriableEntities;

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
