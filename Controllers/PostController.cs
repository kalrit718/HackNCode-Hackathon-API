using BeFit_Server_API.MongoDB;
using Microsoft.AspNetCore.Mvc;

namespace BeFit_Server_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase {

        IWebHostEnvironment _webHostEnvironment;
        MongoConnection _connection;

        public PostController(IWebHostEnvironment env, IConfiguration config) {
            _webHostEnvironment = env;
            _connection = new MongoConnection(config);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosts(string id) {
            try {
                if (string.IsNullOrWhiteSpace(id)) {
                    return BadRequest();
                }
                return await Task.FromResult(Ok(_connection.LoadRecordById(id)));
            }
            catch (ArgumentException ex) {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, "[ERROR]- An unexpected error occured!");
            }
        }
    }
}
