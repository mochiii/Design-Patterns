﻿using System.Data.Entity;

namespace DesignPatterns.Decorator.Before.DB
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Fruit> Fruits => Set<Fruit>();
    }
}
