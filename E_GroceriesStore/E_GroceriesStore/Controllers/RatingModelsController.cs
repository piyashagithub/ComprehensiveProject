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
    public class RatingModelsController : ControllerBase
    {
        private readonly E_GroceryStoreDbContext _context;

        public RatingModelsController(E_GroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/RatingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetRatingModel()
        {
            return await _context.RatingModel.ToListAsync();
        }

        // GET: api/RatingModels/potato
        [HttpGet("{Name}")]
        public async Task<ActionResult<RatingModel>> GetRatingModel(GroceryModel groceryModel)
        {
            var ratingModel = await _context.RatingModel.FindAsync(groceryModel.GroceryName);

            if (ratingModel == null)
            {
                return NotFound();
            }

            return ratingModel;
        }

        

        // POST: api/RatingModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        
        [HttpPost]
        public async Task<ActionResult<RatingModel>> PostRatingModel(RatingModel ratingModel)
        {
            _context.RatingModel.Add(ratingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatingModel", new { id = ratingModel.RatingId }, ratingModel);
        }

        

        
    }
}
