using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Doge.Model;

namespace Doge.WebApp.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : Controller
    {
        private OrderApiClient _orderApiClient;
        public OrdersController()
        {
            _orderApiClient = new OrderApiClient();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Order> orders = await _orderApiClient.GetOrdersAsync();

            ViewBag.Orders = orders;

            return View();
        }
    }
}