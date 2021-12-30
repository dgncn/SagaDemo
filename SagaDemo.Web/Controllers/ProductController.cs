using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SagaDemo.Web.Models;
using SagaDemo.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SagaDemo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ProductBuy()
        {
            var requestModel = new CustomerBuyRequest(1, 1);
            _productService.BuyProduct(requestModel);
            return View();
        }

    }
}
