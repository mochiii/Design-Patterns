using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Decorator.After.DB
{
    public class FruitRepositoryCacheDecorator : IFruitRepository
    {
        private readonly FruitRepository _fruitRepository;
        private readonly Dictionary<int, Fruit> _cache;

        public FruitRepositoryCacheDecorator(FruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
            _cache = new Dictionary<int, Fruit>();
        }

        public void Add(Fruit entity) => _fruitRepository.Add(entity);

        public void Upate(Fruit entity)
        {
            _fruitRepository.Upate(entity);

            if (_cache.ContainsKey(entity.Id))
            {
                _cache[entity.Id] = entity;
            }
        }

        public void Remove(Fruit entity)
        {
            _fruitRepository.Remove(entity);

            _cache.Remove(entity.Id);
        }

        public Fruit Find(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            var entity = _fruitRepository.Find(id);
            if (entity != null)
            {
                _cache[id] = entity;
            }

            return entity;
        }

        public IQueryable<Fruit> GetAll() => _fruitRepository.GetAll();

        public void Dispose() => _fruitRepository.Dispose();
    }
}
