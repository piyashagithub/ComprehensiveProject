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
    public class GroceryModelsController : ControllerBase
    {
        private readonly E_GroceryStoreDbContext _context;

        public GroceryModelsController(E_GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryModel>>> GetGroceryModel()
        {
            return await _context.GroceryModel.ToListAsync();
        }

        // GET: api/GroceryModels/potato
        [HttpGet("{name}")]
        public async Task<ActionResult<GroceryModel>> GetGroceryModel(GroceryModel groceryModel)
        {
            var grocery = await _context.GroceryModel.FindAsync(groceryModel.GroceryName);

            if (grocery == null)
            {
                return NotFound();
            }

            return grocery;
        }

        

       
    }
}
