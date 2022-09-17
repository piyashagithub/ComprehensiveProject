 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_GroceriesStore.DataAccess;
using E_GroceriesStore.Models;

namespace E_GroceriesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderModelsController : ControllerBase
    {
        private readonly E_GroceryStoreDbContext _context;

        public OrderModelsController(E_GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrderModel()
        {
            return await _context.OrderModel.ToListAsync();
        }

        // GET: api/OrderModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderModel(GroceryModel groceryModel)
        {
            if (groceryModel is null)
            {
                throw new ArgumentNullException(nameof(groceryModel));
            }

            var orderModel = await _context.OrderModel.FindAsync(groceryModel.GroceryId);

            if (orderModel == null)
            {
                return NotFound();
            }

            return orderModel;
        }

        

        // POST: api/OrderModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrderModel(OrderModel orderModel)
        {
            _context.OrderModel.Add(orderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderModel", new { id = orderModel.OrderId }, orderModel);
        }

        
    }
}
