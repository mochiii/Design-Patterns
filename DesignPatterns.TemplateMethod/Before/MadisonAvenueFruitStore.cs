using System;
using System.Linq;
using DesignPatterns.TemplateMethod.Before.DB;

namespace DesignPatterns.TemplateMethod.Before
{
    public class MadisonAvenueFruitStore : IDisposable
    {
        private const int FruitFreshnessThresholdDays = 2;

        private readonly FruitRepository _fruitRepository;

        public MadisonAvenueFruitStore()
        {
            _fruitRepository = new FruitRepository();
        }

        public IFruitPackage GetLuxuryFruitPackage()
        {
            var freshUnspoiledFruits = _fruitRepository.GetAll().Where(f => IsFresh(f) && f.Size == FruitSizes.Big);

            var fruitPackage = new MadisonAvenueFruitStorePackage
            {
                Fruits = freshUnspoiledFruits.OrderBy(f => f.Name).ThenByDescending(f => f.ReceptionDate),
                StoreName = "Madison Avenue fruit store"
            };

            return fruitPackage;
        }

        private bool IsFresh(Fruit fruit)
        {
            var isFresh = DateTime.Now - fruit.ReceptionDate > TimeSpan.FromDays(FruitFreshnessThresholdDays);
            return isFresh;
        }

        public void Dispose() => _fruitRepository.Dispose();
    }
}
