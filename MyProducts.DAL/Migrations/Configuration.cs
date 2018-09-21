namespace MyProducts.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyProducts.DAL.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyProducts.DAL.ProductContext context)
        {
            var cat = new List<Category>()
            {
                new Category{ Name = "Patike" },
                new Category{ Name = "Satovi"},
                new Category{ Name = "Rucni alat"}
            };
            var manufac = new List<Manufacturer>()
            {
                new Manufacturer{Name="Hilti"},
                new Manufacturer{Name="Patek Phillipe"},
                new Manufacturer{Name = "Nike"}
            };
            var supplier = new List<Supplier>()
            {
                new Supplier{Name = "Djole transport doo"},
                new Supplier{Name = "EasyTrans INC"}
            };

            foreach (var item in cat)
                context.Categories.AddOrUpdate(c => c.Name, item);

            foreach (var item in manufac)
                context.Manufacturers.AddOrUpdate(m => m.Name, item);

            foreach (var item in supplier)
                context.Suppliers.AddOrUpdate(s => s.Name, item);

            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product{Name = "AirMax 360",        Description = "patike za trcanje" ,     Price=16000, Category = cat[0], Manufacturer=manufac[2], Supplier=supplier[1] },
                new Product{Name = "AirMax VapourMax",  Description = "patike za trcanje" ,     Price=18000, Category = cat[0], Manufacturer=manufac[2], Supplier=supplier[0] },
                new Product{Name = "Nautilus",          Description = "kvalitetan sat" ,        Price=345000, Category = cat[1], Manufacturer=manufac[1], Supplier=supplier[0] },
                new Product{Name = "grandmaster chime", Description = "Luksuzni sat" ,          Price=550000, Category = cat[1], Manufacturer=manufac[1], Supplier=supplier[0] },
                new Product{Name = "Power Drill",       Description = "Busilica od 1800W" ,     Price=25000, Category = cat[2], Manufacturer=manufac[0], Supplier=supplier[1] },
                new Product{Name = "Aku Screwdriver",   Description = "Srafciger na baterije" , Price=22000, Category = cat[2], Manufacturer=manufac[0], Supplier=supplier[1] }
            };

            foreach (var item in products)
                context.Products.AddOrUpdate(p => p.Name, item);

            context.SaveChanges();

        }
    }
}
