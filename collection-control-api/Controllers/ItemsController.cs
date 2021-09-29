using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Items")]
    public class ItemsController : ControllerBase
    {
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
