using LINQ.Data;
using LINQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace LINQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            var existing = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (existing == null) return NotFound();

            existing.CustomerName = order.CustomerName;
            existing.ProductName = order.ProductName;
            existing.Quantity = order.Quantity;
            existing.TotalAmount = order.TotalAmount;
            existing.IsCompleted = order.IsCompleted;

            _context.SaveChanges();
            return Ok("Order updated");
        }

        // DELETE: api/orders/{id} (Soft delete logic)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();

            order.IsCompleted = true;
            _context.SaveChanges();

            return Ok("Order marked as completed");
        }

        // GET: api/orders/completed
        [HttpGet("completed")]
        public IActionResult CompletedOrders()
        {
            var orders = _context.Orders
                .Where(o => o.IsCompleted)
                .ToList();

            return Ok(orders);
        }

        // GET: api/orders/pending
        [HttpGet("pending")]
        public IActionResult PendingOrders()
        {
            var orders = _context.Orders
                .Where(o => !o.IsCompleted)
                .ToList();

            return Ok(orders);
        }
    }
}
