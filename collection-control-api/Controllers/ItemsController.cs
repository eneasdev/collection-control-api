using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();

            return Ok(items);
        }

        public IActionResult GetItemSearch([FromBody] string stringSearch)
        {
            if (string.IsNullOrWhiteSpace(stringSearch)) return NotFound();

            var items = _itemService.GetItemSearch(stringSearch);

            return Ok(items);
        }

        [HttpPost]
        public IActionResult Lend([FromBody] Item item,[FromHeader] Client client)
        {
            if (item == null || client == null) return BadRequest();

            _itemService.Lend(item,client);

            return Ok();
        }
    }
}
