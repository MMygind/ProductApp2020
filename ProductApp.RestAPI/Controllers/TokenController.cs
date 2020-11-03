using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;
using ProductApp.Infrastructure.SQLLite.Data.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApp.RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IUserRepository<User> repository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IUserRepository<User> repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }
    }
}
