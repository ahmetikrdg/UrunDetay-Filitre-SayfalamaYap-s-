using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.data.Concrate.EfCore;
using shopapp.entity;

namespace shopapp.business.Concrate
{
    public class ProductManager : IProductServices
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }
        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public System.Collections.Generic.List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductDetails(int id)
        {
           return _productRepository.GetProductDetails(id);
        }

        public Product GetProductDetails(string Url)
        {
            return _productRepository.GetProductDetails(Url);
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
          return _productRepository.GetProductsByCategory(name,page, pageSize);
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}