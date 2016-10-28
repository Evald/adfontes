using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adfontes.Models;
using Adfontes.Models.Repositories;

namespace Adfontes.Controllers
{

    [Route("api/[controller]")]
    public class NotebookController : Controller
    {
        private IAdfontesRepository<Notebook> _repo;

        public NotebookController(IAdfontesRepository<Notebook> repo){
            this._repo = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<Notebook> Notebooks()
        {
            var notebooks = _repo.GetAll();
            return notebooks;
        }

       [HttpGet("{id}", Name = "GetNotebook")]
        public IActionResult GetNotebookById(int id){
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateNotebook([FromBody]Notebook book)
        {
            _repo.Add(book);

            return this.CreatedAtRoute("GetNotebook", new { controller = "Notebook", id = book.NotebookId }, book);
        }
    }
}
