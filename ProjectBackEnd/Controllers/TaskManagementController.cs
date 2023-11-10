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
        [HttpGet(nameof(GetTaskById))]
        public IActionResult GetTaskById(int Id)
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
        [HttpGet(nameof(GetAllTask))]
        public IActionResult GetAllTask()
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
        [HttpPost(nameof(CreateTask))]
        public IActionResult CreateTask(taskStruct taskVariable)
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
        [HttpPut(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(taskStruct taskVariable)
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
        public IActionResult DeleteStudent(string Id)
        {
            var taskDetails = _customService.Delete(Id);
            return Ok(taskDetails);
        }
    }
}
