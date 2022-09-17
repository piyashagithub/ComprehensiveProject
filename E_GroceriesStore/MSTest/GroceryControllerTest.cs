using AutoFixture;
using E_GroceriesStore.Controllers;
using E_GroceriesStore.DataAccess;
using E_GroceriesStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace MSTest
{
    [TestClass]
    public class GroceryControllerTest
    {
        private Mock<E_GroceryStoreDbContext> _context;
        private Fixture _fixture;  // for creating objects we need when giving the dbcontext fake data
        private GroceryModelsController groceryModelsController; // object of controller

        public GroceryControllerTest()
        {
            _fixture = new Fixture();
            _context = new Mock<E_GroceryStoreDbContext>();
        }
        

    }
}
