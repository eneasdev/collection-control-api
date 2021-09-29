using collection_control_api.Models.InputModels;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    [Route("api/Cds")]
    public class CdsController : ControllerBase
    {
        private readonly ICdService _cdService;
        public CdsController(ICdService cdService)
        {
            _cdService = cdService;
        }
        public IActionResult Create([FromBody] NewCdInputModel inputModel)
        {
            if (inputModel == null) return BadRequest();

            _cdService.Create(inputModel);

            return Ok();
        }
    }
}
