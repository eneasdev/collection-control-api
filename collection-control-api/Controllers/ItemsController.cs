using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    [Route("api/Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemsRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemsRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemsRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{string}")]
        public IActionResult GetItemSearch(string stringSearch)
        {
            if (string.IsNullOrWhiteSpace(stringSearch)) return NotFound();

            var items = _itemsRepository.GetItemSearch(stringSearch);

            return Ok(items);
        }
    }
}
