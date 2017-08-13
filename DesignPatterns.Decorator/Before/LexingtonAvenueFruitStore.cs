using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Decorator.Before.DB;

namespace DesignPatterns.Decorator.Before
{
    public class LexingtonAvenueFruitStore : IDisposable
    {
        private readonly IFruitRepository _fruitRepository;

        public LexingtonAvenueFruitStore()
        {
            _fruitRepository = new FruitRepository();
        }

        public void AddBigFruits(IEnumerable<Fruit> fruits)
        {
            var bigFruits = fruits.Where(f => f.Size == FruitSizes.Big);

            foreach (var fruit in bigFruits)
            {
                _fruitRepository.Add(fruit);
            }
        }

        public Fruit GetFruit(int id)
        {
            var fruit = _fruitRepository.Find(id);
            return fruit;
        }

        public void Dispose() => _fruitRepository.Dispose();
    }
}
