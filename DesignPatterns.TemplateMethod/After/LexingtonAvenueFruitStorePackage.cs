using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.After
{
    public class LexingtonAvenueFruitStorePackage : IFruitPackage
    {
        public IEnumerable<Fruit> Fruits { get; set; }

        public string StoreName { get; set; }
    }
}
