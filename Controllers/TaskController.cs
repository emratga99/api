using Microsoft.AspNetCore.Mvc;
using api.Service;
using api.Model;
namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _service;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _service = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpGet("GetAll")]
        public List<TaskModel> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("GetOne")]
        public IActionResult GetOne(int index)
        {
            try
            {
                var data = _service.GetOne(index);
                if (data == null)
                {
                    return BadRequest("Not Found");
                };
                return new JsonResult(data);

            }
            catch (Exception e)
            {
                return StatusCode(500, "Exception: " + e);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(int index, TaskModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("bad request");
            }
            try
            {
                var data = _service.GetOne(index);
                if (data == null)
                {
                    return BadRequest("Not Found");
                }
                data.ID = person.ID;
                data.Title = person.Title;
                data.IsCompleted = person.IsCompleted;
                var result = _service.Update(data.ID, data);
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error " + e);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int index)
        {
            try
            {
                var person = _service.GetOne(index);
                if (person == null)
                {
                    return BadRequest("Error");
                }
                var result = _service.Delete(person.ID, person);
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error " + e);
            }
        }

        [HttpPost("AddMultiple")]
        public IActionResult AddMultiple([FromBody] List<TaskModel> persons)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var data = persons.Select(p => new
                {
                    ID = Guid.NewGuid().ToString(),
                    p.Title,
                    p.IsCompleted
                });
                var result = _service.AddMultiple(persons);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex);
            }
        }
        [HttpPost("DeleteMultiple")]
        public IActionResult DeleteMultiple(List<string> indexes)
        {
            _service.DeleteMultiple(indexes);
            return Ok();
        }
    }
}