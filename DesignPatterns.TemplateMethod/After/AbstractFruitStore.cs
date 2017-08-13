using System;
using System.Collections.Generic;
using DesignPatterns.TemplateMethod.After.DB;

namespace DesignPatterns.TemplateMethod.After
{
    public abstract class AbstractFruitStore : IDisposable
    {
        private const int FruitFreshnessThresholdDays = 2;

        protected readonly FruitRepository FruitRepository;

        protected AbstractFruitStore()
        {
            FruitRepository = new FruitRepository();
        }

        public virtual IFruitPackage GetLuxuryPackage()
        {
            var fruits = GetFruits();
            var sortedFruits = SortFruits(fruits);
            var fruitPackage = PackageFruits(sortedFruits);

            return fruitPackage;
        }

        public void Dispose() => FruitRepository.Dispose();

        protected bool IsFresh(Fruit fruit)
        {
            var isFresh = DateTime.Now - fruit.ReceptionDate > TimeSpan.FromDays(FruitFreshnessThresholdDays);
            return isFresh;
        }

        protected abstract IEnumerable<Fruit> GetFruits();

        protected abstract IEnumerable<Fruit> SortFruits(IEnumerable<Fruit> fruits);

        protected abstract IFruitPackage PackageFruits(IEnumerable<Fruit> fruits);
    }
}
