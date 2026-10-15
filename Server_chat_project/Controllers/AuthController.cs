using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server_chat_project.Data;
using Server_chat_project.Models;

namespace Server_chat_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost("login")]
        public string Login()
        {
            return "Login Successfull";
        }

        
        [HttpPost("register")]
        public string Register([FromBody]User user)
        {
            if (User == null)
            {
                return "All feild are required";
            }
            if (_dbContext.Users.Any(u => u.UserEmail == user.UserEmail))
            {
                return "User Alerdy exists";
            }

            var userToCreate = new User
            {
                UserEmail = user.UserEmail,
                Username = user.Username,
                HashPassword = user.HashPassword,
            };

            _dbContext.Users.Add(userToCreate);
            _dbContext.SaveChanges();
            console.writeLine("User Registered Successfully");
            return "Register Successfull";
            
        }
    }
}
