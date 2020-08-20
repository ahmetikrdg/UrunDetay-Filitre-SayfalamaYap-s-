using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;

namespace shopapp.webui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
         private ICategoryServices _categoryServices;

        public CategoriesViewComponent(ICategoryServices categoryServices)
        {
            this._categoryServices=categoryServices;
        }
        public IViewComponentResult Invoke()
        {
            if(RouteData.Values["category"]!=null)
            ViewBag.SelectedCategory=RouteData?.Values["category"];
            return View(_categoryServices.GetAll());
        }
    }
}