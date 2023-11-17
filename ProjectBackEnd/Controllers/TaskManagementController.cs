using DomainLayer.ApplicationDbContext;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServiceFolder;

namespace ProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly IService<taskStruct> _customService;
        private readonly appDbContext _applicationDbContext;
        public TaskManagementController(IService<taskStruct> customService, appDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetByUserName))]
        public IActionResult GetByUserName(string userName)
        {
            try
            {
                var obj = _customService.GetByUserName(userName);

                if (obj == null)
                {
                    if (string.IsNullOrEmpty(userName))
                    {
                        // Handle the case where userId is 0 and return an appropriate response.
                        // For example, you might want to return an empty list or a specific message.
                        return Ok(new List<taskStruct>()); // Or return NotFound("No data found for userId 0");
                    }
                    else
                    {
                        return NotFound($"No data found for the specified userName: {userName}");
                    }
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(Create))]
        public IActionResult Create(taskStruct taskVariable)
        {
            
            if (taskVariable != null)
            {
                _customService.Insert(taskVariable);
                return Ok(taskVariable);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPut(nameof(Update))]
        public IActionResult Update(taskStruct taskVariable)
        {
            if (taskVariable != null)
            {
                _customService.Update(taskVariable);
                return Ok(taskVariable);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete(string Id)
        {
            var taskDetails = _customService.Delete(Id);
            return Ok(taskDetails);
        }
    }
}
