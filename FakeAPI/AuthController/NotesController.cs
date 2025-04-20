using Microsoft.AspNetCore.Mvc;

namespace FakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpPost("addNote")]
        public IActionResult AddNote()
        {
            return Ok(new { message = "Note added successfully!" });
        }

        [HttpGet("getUserNotes")]
        public IActionResult GetUserNotes()
        {
            var notes = new[]
            {
                new {
                    _id = "6005c66cfa817d33d436594a",
                    title = "this is a title",
                    desc = "this is a desc",
                }
            };

            return Ok(new
            {
                message = "success",
                notes = notes
            });
        }

        [HttpDelete("deleteNote")]
        public IActionResult DeleteNote()
        {
            return Ok(new { message = "Note deleted successfully!" });
        }

        [HttpPut("updateNote")]
        public IActionResult UpdateNote()
        {
            return Ok(new { message = "Note updated successfully!" });
        }
    }
}
