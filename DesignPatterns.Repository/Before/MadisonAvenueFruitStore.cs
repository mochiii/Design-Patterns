using System;
using System.Linq;
using DesignPatterns.Repository.Before.DB;

namespace DesignPatterns.Repository.Before
{
    public class MadisonAvenueFruitStore : IDisposable
    {
        private readonly DbContext _dbContext;

        public MadisonAvenueFruitStore()
        {
            _dbContext = new DbContext();
        }

        public Fruit GetFruit(int id)
        {
            var fruit = _dbContext.Fruits.SingleOrDefault(f => f.Id == id);
            return fruit;
        }

        public void MarkFruitSpoiled(Fruit fruit)
        {
            fruit.IsSpoiled = true;

            _dbContext.SaveChanges();
        }

        public void DiscardSpoiledFruits()
        {
            var spoiledFruits = _dbContext.Fruits.Where(f => f.IsSpoiled);
            _dbContext.Fruits.RemoveRange(spoiledFruits);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
