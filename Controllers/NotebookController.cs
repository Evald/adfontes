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

        [HttpGet]
        public async Task<IEnumerable<Notebook>> Notebooks()
        {
            var notebooks = await _repo.GetAll();
            return notebooks;
        }

       [HttpGet("{id}")]
        public async Task<IActionResult> GetNotebookById(int id){
            var notebook = await _repo.GetById(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return Json(notebook);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotebook([FromBody]Notebook book)
        {
            var notebook = await _repo.Add(book);
            if (notebook == null)
            {
                return NotFound();
            }
            return Json(notebook);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotebook([FromBody]Notebook book)
        {
            var notebook = await _repo.Edit(book);
            if (notebook == null)
            {
                return NotFound();
            }
            return Json(notebook);
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNotebook(int id)
        {             
            var notebook = await _repo.Remove(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return Json(notebook);
            
        }
    }
}
