using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult GetById(int id)
        {
            if (id < 1) return NotFound();

            var book = _bookService.GetById(id);

            return Ok(book);
        }
    }
}
