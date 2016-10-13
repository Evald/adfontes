using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adfontes.Models;

namespace Adfontes.Controllers
{

    [Route("api/[controller]")]
    public class NotebookController : Controller
    {
        private INoteRepository _repo;

        public NotebookController(INoteRepository repo){
            this._repo = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<Notebook> Notebooks()
        {
            return _repo.GetNotebooks();
        }

       [HttpGet("{id}", Name = "GetNotebook")]
        public IActionResult GetNotebookById(int id){
            return new JsonResult(_repo.GetNotebook(id));
        }

        [HttpPost]
        public IActionResult CreateNotebook([FromBody]Notebook book)
        {
            _repo.AddNotebook(book);

            return this.CreatedAtRoute("GetNotebook", new { controller = "Notebook", id = book.NotebookId }, book);
        }
    }
}
