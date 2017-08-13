using System;
using System.Linq;
using DesignPatterns.TemplateMethod.Before.DB;

namespace DesignPatterns.TemplateMethod.Before
{
    public class LexingtonAvenueFruitStore : IDisposable
    {
        private const int FruitFreshnessThresholdDays = 2;

        private readonly FruitRepository _fruitRepository;

        public LexingtonAvenueFruitStore()
        {
            _fruitRepository = new FruitRepository();
        }

        public IFruitPackage GetLuxuryPackage()
        {
            var freshUnspoiledFruits = _fruitRepository.GetAll().Where(
                f => IsFresh(f) && !f.IsSpoiled && f.Size == FruitSizes.Small);

            var fruitPackage = new LexingtonAvenueFruitStorePackage
            {
                Fruits = freshUnspoiledFruits.OrderByDescending(f => f.Name),
                StoreName = "Freshest NY fruit store"
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
