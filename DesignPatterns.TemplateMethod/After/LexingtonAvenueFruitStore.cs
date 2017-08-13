using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.TemplateMethod.After
{
    public class LexingtonAvenueFruitStore : AbstractFruitStore
    {
        protected override IEnumerable<Fruit> GetFruits()
        {
            var freshUnspoiledFruits = FruitRepository.GetAll().Where(
                f => IsFresh(f) && !f.IsSpoiled && f.Size == FruitSizes.Small);
            return freshUnspoiledFruits;
        }

        protected override IEnumerable<Fruit> SortFruits(IEnumerable<Fruit> fruits)
        {
            var sortedFruits = fruits.OrderByDescending(f => f.Name);
            return sortedFruits;
        }

        protected override IFruitPackage PackageFruits(IEnumerable<Fruit> fruits)
        {
            var fruitPackage = new LexingtonAvenueFruitStorePackage
            {
                Fruits = fruits,
                StoreName = "Freshest NY fruit store"
            };

            return fruitPackage;
        }
    }
}
