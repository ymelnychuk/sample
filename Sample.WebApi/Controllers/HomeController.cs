using Sample.Data.Repository;
using Sample.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [AllowCrossSiteJson]
        public JsonResult GetProducts(int? skip, int? take, String sort)
        {
            Int32 pageSize = take ?? 10;
            Int32 skipIndex = skip ?? 1;
            Int32 pageIndex = skipIndex / pageSize + 1;
            
            var list = _productRepository.GetAll(pageIndex, pageSize, sort);
            var total = _productRepository.GetAllCount();

            return Json(new { data = list, total }, JsonRequestBehavior.AllowGet);
        }
    }
}
