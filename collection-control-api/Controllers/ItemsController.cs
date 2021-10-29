using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemService;
        public ItemsController(IItemRepository itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();
        
            return Ok(items);
        }

        [HttpGet("{string}")]
        public IActionResult GetItemSearch(string stringSearch)
        {
            if (string.IsNullOrWhiteSpace(stringSearch)) return NotFound();

            var items = _itemService.GetItemSearch(stringSearch);

            return Ok(items);
        }

        [HttpPost]
        public IActionResult Lend([FromBody] Loan loanInput)
        {
            if (loanInput == null) return BadRequest();

            _itemService.Lend(loanInput);

            return Ok();
        }
    }
}
