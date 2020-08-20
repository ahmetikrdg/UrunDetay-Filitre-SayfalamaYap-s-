using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrate.EfCore
{
    public class EfCorePrductRepository : EfCoreGenericRepository<Product,ShopContext>,IProductRepository
    {
        private ShopContext db=new ShopContext();

        public List<Product> GetPopularProducts()
        {
           using(var context=new ShopContext())
            {
              return context.Products.ToList();
            }
        }

        public Product GetProductDetails(int id)
        {
            using(var context=new ShopContext())
            {
              return context.Products
              .Where(i=>i.ProductId==id)
              .Include(i=>i.productCategories)//ben producttan productcategoriese giderim
              .ThenInclude(i=>i.Category)//productcategoryden'de category'e geçiyorum
              .FirstOrDefault();//ilgili ıdye uyan product bigisi varsa bulduğun ilk kaydı bana getir ve getirirkende ekstra join işlemimi yapıyorum ıcloud then lerde
            }
        }

        public Product GetProductDetails(string Url)
        {
            using(var context=new ShopContext())
            {
              return context.Products
              .Where(i=>i.Url==Url)
              .Include(i=>i.productCategories)//ben producttan productcategoriese giderim
              .ThenInclude(i=>i.Category)//productcategoryden'de category'e geçiyorum
              .FirstOrDefault();//ilgili ıdye uyan product bigisi varsa bulduğun ilk kaydı bana getir ve getirirkende ekstra join işlemimi yapıyorum ıcloud then lerde
            }
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
            using(var context=new ShopContext())
            {
              var products=context.Products.AsQueryable();
              //asquaribale şu demek ben sorguyu yazıyorum fakat vt'ye sorgu göndermeden önce üstüne ekstra bir linq sorgusu bir kriter eklemek istiyorum demek

              if(!string.IsNullOrEmpty(name))
              {
                products=products
                .Include(i=>i.productCategories)
                .ThenInclude(i=>i.Category) //iligli kayıtların referanslara ulaşıyoruz ve sonra ilgili kaydın productcategorieslerine gidiyoruz ve productcat üzerinden categoriy'e geçiyrouz ve gönderdiğimiz bir category'e ait ürün varsa any metodu bana true değer gönderiyo buda true geliyosa ürünü bana getir demek
                .Where(i=>i.productCategories.Any(a=>a.Category.Url==name));
              }
              return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
              //skip : 5 yazarsan 5 tane ürünü öteler ve take metodu aracılığıyla kaç ürnü almak istediğini söylersin
              //yani kayıt içinden ilk 5 ürün değilde 2. 5 ürünü almış olur products.Skip(5).Take(5).ToList(); takeye 5 yerine pagesize yazdım ordan gelen değere göre alsın
            }
        }

        // public void Create(Product entity)
        // {
        //     db.Products.Add(entity);
        //     db.SaveChanges();
        // }

        // public void Delete(int entity)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public List<Product> GetAll()
        // {
        //     throw new System.NotImplementedException();
        // }

        // public Product GetById(int id)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public List<Product> GetPopularProducts()
        // {
        //     throw new System.NotImplementedException();
        // }

        // public void Update(Product product)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}