using E_GroceriesStore.DataAccess;
using E_GroceriesStore.Models;
using E_GroceriesStore.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_GroceriesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowCrossOrigin")]
    public class AccountController : ControllerBase
    {
        private readonly E_GroceryStoreDbContext _context;
        private readonly IUser _user;

        public AccountController(E_GroceryStoreDbContext e_GroceryStoreDbContext, IUser user)
        {
            _context = e_GroceryStoreDbContext;
            _user = user;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult<ResponseModel>> SignUp([FromBody] UserModel userModel)
        {
            try
            {
                var response = await _user.SignUp(userModel);
                return response;
            }
            catch (Exception ex)
            {
                ResponseModel response = new ResponseModel();
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseModel>> Login(LoginModel loginModel)
        {
            try
            {
                var user = await _context.UserModel.Where(i => i.UserName == loginModel.UserName &&
                                                              i.Password == loginModel.Password).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("Invalid Credential");
                }

                var claims = new List<Claim>
                {
                    new Claim(type:ClaimTypes.Name, value:user?.UserName)
                    
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return Ok("Login Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
