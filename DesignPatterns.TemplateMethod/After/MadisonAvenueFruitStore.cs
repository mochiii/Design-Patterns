using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.TemplateMethod.After
{
    public class MadisonAvenueFruitStore : AbstractFruitStore
    {
        protected override IEnumerable<Fruit> GetFruits()
        {
            var freshUnspoiledFruits = FruitRepository.GetAll().Where(f => IsFresh(f) && f.Size == FruitSizes.Big);
            return freshUnspoiledFruits;
        }

        protected override IEnumerable<Fruit> SortFruits(IEnumerable<Fruit> fruits)
        {
            var sortedFruits = fruits.OrderBy(f => f.Name).ThenByDescending(f => f.ReceptionDate);
            return sortedFruits;
        }

        protected override IFruitPackage PackageFruits(IEnumerable<Fruit> fruits)
        {
            var fruitPackage = new MadisonAvenueFruitStorePackage
            {
                Fruits = fruits,
                StoreName = "Madison Avenue fruit store"
            };

            return fruitPackage;
        }
    }
}
