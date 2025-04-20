using Microsoft.AspNetCore.Mvc;

namespace FakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        [HttpPost("addToFavorites")]
        public IActionResult AddToFavorites()
        {
            return Ok(new { message = "Movie added to favorites!" });
        }

        [HttpGet("getFavorites")]
        public IActionResult GetFavorites()
        {
            var favorites = new[]
            {
                new {
                    _id = "6005a12c5d03ca24dcaf3146",
                    movieName = "Cast Away",
                    imgUrl = "https://www.pluggedin.com/9.jpg",
                    userID = "5edd7a356573a6001774adb8",
                    movieID = "12345"
                }
            };

            return Ok(new
            {
                message = "success",
                favorites = favorites
            });
        }
    }
}
