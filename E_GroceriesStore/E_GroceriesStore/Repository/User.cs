using E_GroceriesStore.DataAccess;
using E_GroceriesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.Repository
{
    public class User : IUser
    {
        private readonly E_GroceryStoreDbContext _e_GroceryStoreDbContext;

        public User(E_GroceryStoreDbContext e_GroceryStoreDbContext)
        {
            _e_GroceryStoreDbContext = e_GroceryStoreDbContext;
        }

        public Task<ResponseModel> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> SignUp(UserModel userModel)
        {
            try
            {
                var res = _e_GroceryStoreDbContext.UserModel.Add(userModel);
                await _e_GroceryStoreDbContext.SaveChangesAsync();
                if (res != null)
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = "Registration Successful";
                    return responseModel;
                }
                else
                {
                    throw new Exception("Registration not successful");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
