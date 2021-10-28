using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    [Route("api/Clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 1) return BadRequest();

            var client = _clientRepository.GetById(id);

            if (client == null) return NotFound();

            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] string clientName)
        {
            if (string.IsNullOrEmpty(clientName)) return BadRequest();

            _clientRepository.Create(clientName);

            return Ok();
        }
    }
}
