using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class ProductDetailModel
    {
         public Product Product { get; set; }
         public List<Category> Category { get; set; }
    }
}