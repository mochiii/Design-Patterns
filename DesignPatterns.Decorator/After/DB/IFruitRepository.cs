using System;
using System.Linq;

namespace DesignPatterns.Decorator.After.DB
{
    public interface IFruitRepository : IDisposable
    {
        void Add(Fruit entity);

        void Upate(Fruit entity);

        void Remove(Fruit entity);

        Fruit Find(int id);

        IQueryable<Fruit> GetAll();
    }
}