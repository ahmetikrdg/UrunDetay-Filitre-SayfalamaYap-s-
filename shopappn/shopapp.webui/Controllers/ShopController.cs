using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{ 
    public class ShopController:Controller
    {
        private IProductServices _productService;
        public ShopController(IProductServices productService)
        {
            this._productService=productService;
        }
         //localhost/products/telefon?page=1
        public IActionResult List(string category,int page=1)
        {
            const int pageSize=4;
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            };

            return View(productViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url==null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(url);

            if(product==null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel{
                Product = product,
                Category = product.productCategories.Select(i=>i.Category).ToList()
            });
        }
    }
}