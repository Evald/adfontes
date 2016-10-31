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
    public class NoteController : Controller
    {
        private NoteRepository _repo;

        public NoteController(NoteRepository repo){
            this._repo = repo;
        }

        // GET: /api/Note/
        // the id represents the id of the parent note
        [HttpGet("Parent/{parentId}")]
        public async Task<IEnumerable<Note>> Notes(int parentId)
        {
            var Notes = await _repo.GetAllByParentId(parentId);
            return Notes;
        }

        // GET: /api/Note/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id){
            var Note = await _repo.GetById(id);
            if (Note == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Note);
        }

        // POST: /api/Note
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody]Note note)
        {
            var Note = await _repo.Add(note);
            if (Note == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Note);
        }

        // PUT: /api/Note
        [HttpPatch]
        public async Task<IActionResult> UpdateNote([FromBody]Note note)
        {
            var Note = await _repo.Edit(note);
            if (Note == null)
            {   
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Note);
            
        }

        // DELETE: /api/Note/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNote(int id)
        {             
            var Note = await _repo.Remove(id);
            if (Note == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Note);
            
        }
    }
}
