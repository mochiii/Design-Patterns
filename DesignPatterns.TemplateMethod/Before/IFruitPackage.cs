using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.Before
{
    public interface IFruitPackage
    {
        IEnumerable<Fruit> Fruits { get; set; }

        string StoreName { get; set; }
    }
}
