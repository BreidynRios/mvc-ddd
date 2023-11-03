using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(
            IClientService clientService,
            IProductService productService,
            IOrderService orderService)
        {
            _clientService = clientService;
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Clients = new SelectList(await _clientService.List(), "Id", "FullName");
            ViewBag.Products = new SelectList(await _productService.List(), "Id", "Description");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder([FromBody] OrderDto order)
        {
            var success = await _orderService.Save(order);
            return success 
                ? Json("El pedido se guardó de manera exitosa")
                : Json("Ingrese los productos");
        }
    }
}