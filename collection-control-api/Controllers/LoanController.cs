using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

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
            var items = _loanRepository.GetAll();
        
            return Ok(items);
        }

        [HttpGet("{string}")]
        public IActionResult GetItemSearch(string stringSearch)
        {
            if (string.IsNullOrWhiteSpace(stringSearch)) return NotFound();

            var items = _loanRepository.GetItemSearch(stringSearch);

            return Ok(items);
         }

        [HttpPost]
        public IActionResult Lend(NewLoanInputModel loanInputModel)
        {
            if (loanInputModel == null) return BadRequest();

            if (loanInputModel.ClientId <= 0 || loanInputModel.ItemId <= 0) return BadRequest();

            _loanRepository.Lend(loanInputModel);

            return Ok();
        }
    }
}
