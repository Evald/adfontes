
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Adfontes.Models.Repositories {

    public class NotebookRepository
    {
        private ApplicationDbContext _context;

        public NotebookRepository(ApplicationDbContext context){
            this._context = context;
        }
        public async Task<Notebook> Add(Notebook entity)
        {
            
            // Gets the user resource using hardcoded username until
            // Identiserver4 is implemented with token authentication.
            var author = await _context.Users.SingleOrDefaultAsync(u => u.UserName == "Evald");

            var notebook = _context.Notebooks.Add(new Notebook {
               Title = entity.Title,
               Author = author,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }).Entity;
            await _context.SaveChangesAsync();

            return notebook;
        }

        public async Task<Notebook> Edit(Notebook entity)
        {
            // Gets resource using provided id and updates allowed properties.
            var notebook = await this.GetById(entity.NotebookId);

            notebook.Title = entity.Title;
            notebook.UpdatedAt = DateTime.Now;

           await _context.SaveChangesAsync();

           return notebook;
        }

        public async Task<IEnumerable<Notebook>> GetAll()
        {
            // Gets and returns all resources as an IEnumerable.
            var notebooks = await _context.Notebooks.ToListAsync();
            return notebooks;
        }

        public async Task<Notebook> GetById(int id)
        {
            // Gets the resource using provided id.
            var notebook = await _context.Notebooks.SingleOrDefaultAsync(n => n.NotebookId == id);
            return notebook;
        }

        public async Task<Notebook> Remove(int id)
        {
            // Deletes resource and associated resources using provided id
            var notebook = await _context.Notebooks.Where(n => n.NotebookId == id).Include(book => book.Notes).ThenInclude(notes => notes.Components).SingleAsync();
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
            
            return notebook;
        }        
    }
}