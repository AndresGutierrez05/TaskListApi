using BD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using TaskListAPI.Models;

namespace TaskListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ToDoListContext _context;
        private const string catchError = "an error has occurred";
        private const string idNotfound = "Id not found";

        public TaskController(ToDoListContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get One specific task
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetOne(int id) {
            Tasks? task = _context.Tasks.Find(id);
            if (task != null)
                return Ok(task);
            else
                return BadRequest(idNotfound);
        } 

        /// <summary>
        /// Gets all tasks
        /// </summary>
        [HttpGet()]
        public ActionResult GetAll() => Ok(_context.Tasks.ToList());

        ///<summary>
        ///Create task
        ///</summary>
        [HttpPost]
        public ActionResult Create(TaskModel newTask)
        {
            try
            {
                if(!string.IsNullOrEmpty(newTask.Title) && !string.IsNullOrEmpty(newTask.Description))
                {
                    _context.Tasks.Add(new Tasks { Title = newTask.Title,  Description = newTask.Description, Completed = newTask.Completed ?? false });
                    _context.SaveChanges();
                    return Created("", "created successfuly");
                }else
                    return BadRequest("Title and Description are mandatory");
            }
            catch
            {
                return Problem(detail: catchError);
            }
        }

        /// <summary>
        /// Update a specific task
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] TaskModel body)
        {
            try
            {
                Tasks? task = _context.Tasks.Find(id);
                if (task != null)
                {
                    task.Title = body.Title ?? task.Title;
                    task.Description = body.Description ?? task.Description;
                    task.Completed = body.Completed ?? task.Completed;
                    _context.Tasks.Update(task);
                    _context.SaveChanges();
                    return Ok("updated successfuly");
                }
                else
                {
                    return BadRequest(idNotfound);
                }
            }
            catch
            {
                return Problem(detail: catchError);
            }
        }


        /// <summary>
        /// Delete a task
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Tasks? task = _context.Tasks.Find(id);
                if(task != null)
                {
                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                    return Ok("deleted successfuly");
                }
                else
                {
                    return BadRequest(idNotfound);
                }
            }
            catch
            {
                return Problem(detail: catchError);
            }
        }
    }
}
