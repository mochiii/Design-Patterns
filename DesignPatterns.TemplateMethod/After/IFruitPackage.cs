using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.After
{
    public interface IFruitPackage
    {
        IEnumerable<Fruit> Fruits { get; set; }

        string StoreName { get; set; }
    }
}
