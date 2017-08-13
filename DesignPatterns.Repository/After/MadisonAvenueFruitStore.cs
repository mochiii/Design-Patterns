using System;
using System.Linq;
using DesignPatterns.Repository.After.DB;

namespace DesignPatterns.Repository.After
{
    public class MadisonAvenueFruitStore : IDisposable
    {
        private readonly FruitRepository _fruitRepository;

        public MadisonAvenueFruitStore()
        {
            _fruitRepository = new FruitRepository();
        }

        public Fruit GetFruit(int id)
        {
            var fruit = _fruitRepository.Find(id);
            return fruit;
        }

        public void MarkFruitSpoiled(Fruit fruit)
        {
            fruit.IsSpoiled = true;

            _fruitRepository.Upate(fruit);
        }

        public void DiscardSpoiledFruits()
        {
            var spoiledFruits = _fruitRepository.GetAll().Where(f => f.IsSpoiled);

            foreach (var spoiledFruit in spoiledFruits)
            {
                _fruitRepository.Remove(spoiledFruit);
            }
        }

        public void Dispose() => _fruitRepository.Dispose();
    }
}
