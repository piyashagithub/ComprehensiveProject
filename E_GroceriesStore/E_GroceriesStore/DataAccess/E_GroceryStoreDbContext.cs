using E_GroceriesStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.DataAccess
{
    public class E_GroceryStoreDbContext : DbContext
    {
        public E_GroceryStoreDbContext(DbContextOptions<E_GroceryStoreDbContext> options) : base(options)
        {

        }


        public DbSet<UserModel> UserModel { get; set; } // Dbset is a datatype that represents a TABLE/model && make a table in database with name UserModel
        public DbSet<LoginModel> LoginModel { get; set; }
        public DbSet<ResponseModel> ResponseModel { get; set; }

        public DbSet<BuyModel> BuyModel { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<CartModel> CartModel { get; set; }
        public DbSet<GroceryModel> GroceryModel { get; set; }
        public DbSet<RatingModel> RatingModel { get; set; }


    }
}
