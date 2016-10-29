using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adfontes.Models;
using Adfontes.Models.ViewModels;
using Adfontes.Models.Repositories;

namespace Adfontes.Controllers
{

    [Route("api/[controller]")]
    public class NotebookController : Controller
    {
        private NotebookRepository _repo;

        public NotebookController(NotebookRepository repo){
            this._repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<List<Notebook>> Notebooks()
        {
            var notebooks = await _repo.GetAll();
            return notebooks;
        }

       [HttpGet("{id}", Name = "GetNotebook")]
        public async Task<IActionResult> GetNotebookById(int id){
            var notebook = await _repo.GetById(id);
            return Json(notebook);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotebook([FromBody]NotebookAddViewModel book)
        {
            var notebook = await _repo.Add(book);
            return Json(notebook);
            
        }
    }
}
