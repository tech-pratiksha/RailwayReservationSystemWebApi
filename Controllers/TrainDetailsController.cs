using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservationsystem_WebAPI.Data;
using Railway_Reservationsystem_WebAPI.Models;

//Train Details Controller
namespace Railway_Reservationsystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainDetailsController : ControllerBase
    {
        //DB Context
        private readonly LoginDbContext _context;
        public TrainDetailsController(LoginDbContext loginDbContext)
        {
            _context = loginDbContext;

        }

        //get method
        [HttpGet("TrainDetails")]
        public IActionResult GetUsers()
        {
            //getting details from TrainDetailsModels As a List 
            var userdetails = _context.TrainDetailsModels.AsQueryable();
            //returning data fetched via above query
            return Ok( new
            { 
                StatusCode=200,    
                TrainDetails = userdetails //returning object
            
            } );
        }

        //post method
        [HttpPost("getTrainDetails")]
        public IActionResult getTrainDetails([FromBody] TrainDetails obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                var trainObj = _context.TrainDetailsModels.Where(a =>
                a.SourceStation == obj.SourceStation
                && a.DestinationStation == obj.DestinationStation).FirstOrDefault();
                if (trainObj != null)
                {
                    //Return object if train found
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Train found",
                        TrainInfo = trainObj
                    });
                }
                else
                {
                    //Return object if train not found
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Train not found for this route"
                    });
                }

            }
        }

    }
}
