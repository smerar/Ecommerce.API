using Ecommerce.API.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IOrderService _orderService;
       
        public OrderController(IOrderService orderService) { _orderService = orderService; }
    }
}
