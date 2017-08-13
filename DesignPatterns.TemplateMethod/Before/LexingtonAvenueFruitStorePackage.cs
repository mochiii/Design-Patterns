using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.Before
{
    public class LexingtonAvenueFruitStorePackage : IFruitPackage
    {
        public IEnumerable<Fruit> Fruits { get; set; }

        public string StoreName { get; set; }
    }
}
