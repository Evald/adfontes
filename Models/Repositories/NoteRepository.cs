
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Adfontes.Models.Repositories {

    public class NoteRepository
    {
        private ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context){
            this._context = context;
        }

        public async Task<Note> Add(Note entity)
        {
            // Gets the notes parent notebook.
            var parentNotebook = await _context.Notebooks.SingleOrDefaultAsync(n => n.NotebookId == entity.NotebookId);

            // Gets the user resource using hardcoded username until
            // Identiserver4 is implemented with token authentication.
            var author = await _context.Users.SingleOrDefaultAsync(u => u.UserName == "Evald");

            var note = _context.Notes.Add(new Note {
               Title = entity.Title,
               Notebook = parentNotebook,
               Author = author,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }).Entity;

            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<Note> Edit(Note entity)
        {
            // Gets resource using provided id and updates allowed properties.
            var note = await _context.Notes.Where(c => c.NoteId == entity.NoteId).Include(t => t.Notebook).SingleOrDefaultAsync();

            note.Title = entity.Title;
            note.UpdatedAt = DateTime.Now;
            //Sets the UpdatedAt property of the parent note
            note.Notebook.UpdatedAt = DateTime.Now;

           await _context.SaveChangesAsync();

           return note;
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            // Gets and returns all resources as an IEnumerable.           
            var note = await _context.Notes.Include(t => t.Author).Include(c => c.Components).ToListAsync();
            return note;
        }

        public async Task<IEnumerable<Note>> GetAllByParentId(int parentId)
        {
            // Gets and returns all resources associated with parent as an IEnumerable.           
            var note = await _context.Notes.Where(c => c.NotebookId == parentId).Include(t => t.Author).Include(t => t.Components).ToListAsync();
            return note;
        }

        public async Task<Note> GetById(int id)
        {
            // Gets the resource using provided id.
            var note = await _context.Notes.SingleOrDefaultAsync(n => n.NoteId == id);
            return note;
        }

        public async Task<Note> Remove(int id)
        {
           // Deletes resource and associated resources using provided id
            var note = await _context.Notes.Where(n => n.NoteId == id).Include(c => c.Components).SingleAsync();
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();
            
            return note;
        }
    }
}