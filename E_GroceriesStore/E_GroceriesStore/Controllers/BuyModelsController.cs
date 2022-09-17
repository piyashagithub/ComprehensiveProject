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
    public class BuyModelsController : ControllerBase
    {
        private readonly E_GroceryStoreDbContext _context;

        public BuyModelsController(E_GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/BuyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyModel>>> GetBuyModel()
        {
            return await _context.BuyModel.ToListAsync();
        }

        // GET: api/BuyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyModel>> GetBuyModel(int id)
        {
            var buyModel = await _context.BuyModel.FindAsync(id);

            if (buyModel == null)
            {
                return NotFound();
            }

            return buyModel;
        }

       

        // POST: api/BuyModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BuyModel>> PostBuyModel(BuyModel buyModel)
        {
            _context.BuyModel.Add(buyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyModel", new { id = buyModel.BuyId }, buyModel);
        }

        
       
    }
}
