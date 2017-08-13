using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Repository.Before.DB;

namespace DesignPatterns.Repository.Before
{
    public class LexingtonAvenueFruitStore : IDisposable
    {
        private readonly DbContext _dbContext;

        public LexingtonAvenueFruitStore()
        {
            _dbContext = new DbContext();
        }

        public void AddBigFruits(IEnumerable<Fruit> fruits)
        {
            var bigFruits = fruits.Where(f => f.Size == FruitSizes.Big);

            foreach (var fruit in bigFruits)
            {
                _dbContext.Fruits.Add(fruit);
            }

            _dbContext.SaveChanges();
        }

        public Fruit GetFruit(int id)
        {
            var fruit = _dbContext.Fruits.SingleOrDefault(f => f.Id == id);
            return fruit;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
