using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace collection_control_api.Controllers
{
    [Route("api/Loans")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loans = _loanRepository.GetAll();

            return Ok (loans);
        }

        [HttpPost]
        public IActionResult Lend(NewLoanInputModel loanInputModel)
        {
            if (loanInputModel == null) return BadRequest();

            _loanRepository.Lend(loanInputModel);

            return Ok();
        }
    }
}
