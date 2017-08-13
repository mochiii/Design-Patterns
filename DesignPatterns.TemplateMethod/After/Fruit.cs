using System;

namespace DesignPatterns.TemplateMethod.After
{
    public class Fruit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FruitSizes Size { get; set; }

        public DateTime ReceptionDate { get; set; }

        public bool IsSpoiled { get; set; }
    }
}
