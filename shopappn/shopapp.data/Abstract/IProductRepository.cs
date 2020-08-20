using System.Collections.Generic;
using shopapp.entity;
namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {//hernagi bir database türüne özgü kod yazmadık sadece ıproductrepost yazdık bunu diğer webui da kullanıyor lucaz.Snala sınıfın dolu metodu ise concrate içinde hazırlanır
      
        Product GetProductDetails(int id);
        Product GetProductDetails(string Url);

       List<Product> GetProductsByCategory(string name,int page,int pageSize);
       List<Product> GetPopularProducts();//buda sadece producta özel operasyonum
      
        //  Product GetById(int id);
        //  List<Product> GetAll();
        //  void Create(Product product);
        //  void Update(Product product);
        //  void Delete(int product);
    }
}