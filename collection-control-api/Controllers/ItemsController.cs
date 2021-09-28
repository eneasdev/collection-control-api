using collection_control_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Items")]
    public class ItemsController : ControllerBase
    {
        public IActionResult Post([FromBody] NewItemInputModel itemInputModel)
        {
            return Ok();
        }
    }
}
