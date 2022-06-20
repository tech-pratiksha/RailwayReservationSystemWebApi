using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservationsystem_WebAPI.Data;
using Railway_Reservationsystem_WebAPI.Models;

namespace Railway_Reservationsystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginDbContext _context;
        public LoginController(LoginDbContext loginDbContext)
        {
            _context = loginDbContext;

        }
        /*[HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.loginModels.AsQueryable();
            return Ok(userdetails);
        }*/

       
        //post method
        [HttpPost("register")]
        public IActionResult Registration([FromBody] Registration registerObj)
        {
            if(registerObj == null)
            {
                return BadRequest();
            }
            else
            {
                //save data 
                _context.registrationModels.Add(registerObj);
                _context.SaveChanges();

                //returning object if user has registered
                return Ok(new 
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"
                });
            }
        }

        //get method
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            //fetch the user list from Registration Model as List
            var userdetails = _context.registrationModels.AsQueryable();
            return Ok(userdetails);
            //returning data fetched via above query

        }

        /*Login method
         * Get user information from user and
         * validate the information
        */
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginObj)
        {
            if (loginObj == null)
            {
                return BadRequest();
            }
            else
            {
                //Compare the information sent by the user from login form
                var user = _context.registrationModels.Where(a =>
                a.EmailId == loginObj.EmailId
                && a.Password == loginObj.Password).FirstOrDefault();
                if (user != null)
                {
                    //if user found sent back success object
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in Sucessfully",
                        UserData = loginObj.EmailId
                    });
                }
                else
                {
                    //if user not found sent back not found object
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }

            }
        }

        /*[HttpPost("login")]
        public IActionResult Login([FromBody] Login loginObj)
        {
            if (loginObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.loginModels.Where(a =>
                a.Name == loginObj.Name
                && a.Password == loginObj.Password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in Sucessfully",
                        UserData = loginObj.Name
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }


            }
        }*/
    }
}
