using E_GroceriesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.Repository
{
    public interface IUser
    {
        Task<ResponseModel> SignUp(UserModel userModel);
        Task<ResponseModel> Login(LoginModel loginModel);
    }
}
