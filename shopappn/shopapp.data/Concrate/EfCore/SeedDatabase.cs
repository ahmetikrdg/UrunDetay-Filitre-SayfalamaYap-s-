using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrate.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context=new ShopContext();

            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(categories);
                }
            }
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Products.Count()==0)
                {
                    context.Products.AddRange(products);
                    context.AddRange(productCategories);//illa entitye gerek yok dbsete falan context dediğimizde zaten context tarafından tanınıyor
                }
            }
            context.SaveChanges();
        }

        private static Category[] categories=
        {
            new Category(){Name="Telefon",Url="telefon"},
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
            new Category(){Name="Elektronik",Url="elektronik"},
            new Category(){Name="Beyaz Eşya",Url="beyaz-esya"}

        };

        private static Product[] products=
        {
            new Product(){Name="Samsung s5",Url="samsung-s5",Price=2000,ImageUrl="1.jpg",Description="İyi Telefon",IsApproved=true},
            new Product(){Name="Samsung s6",Url="samsung-s6",Price=2000,ImageUrl="2.jpg",Description="İyi Telefon",IsApproved=true},
            new Product(){Name="Samsung s7",Url="samsung-s7",Price=2000,ImageUrl="3.jpg",Description="İyi Telefon",IsApproved=true},
            new Product(){Name="Samsung s8",Url="samsung-s8",Price=2000,ImageUrl="4.jpg",Description="İyi Telefon",IsApproved=true},
            new Product(){Name="Samsung s9",Url="samsung-s9",Price=2000,ImageUrl="5.jpg",Description="İyi Telefon",IsApproved=true},

        };

        private static ProductCategory[] productCategories=
        {
            new ProductCategory(){Products=products[0],Category=categories[0]}, //category ve products claslarına yukarıdaki şeyleri atıyorum
            new ProductCategory(){Products=products[0],Category=categories[2]},
            new ProductCategory(){Products=products[1],Category=categories[0]},
            new ProductCategory(){Products=products[1],Category=categories[2]},
            new ProductCategory(){Products=products[2],Category=categories[0]},
            new ProductCategory(){Products=products[2],Category=categories[2]},
            new ProductCategory(){Products=products[3],Category=categories[0]},
            new ProductCategory(){Products=products[3],Category=categories[2]}
        };



        
    }
}