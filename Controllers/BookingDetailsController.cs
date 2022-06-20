using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservationsystem_WebAPI.Data;
using Railway_Reservationsystem_WebAPI.Models;

namespace Railway_Reservationsystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly LoginDbContext _context;
        public BookingDetailsController(LoginDbContext loginDbContext)
        {
            _context = loginDbContext;

        }
        [HttpPost("BookingDetails")]
        public IActionResult BookingDetails([FromBody] BookingDetails BookingDetailsObj)
        {
            if (BookingDetailsObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.BookingDetailsModels.Add(BookingDetailsObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"
                });
            }
        }
        [HttpGet("BookingDetails")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.BookingDetailsModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                BookingDetails = userdetails
            });


        }
    }
}
