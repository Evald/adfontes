
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;
using Adfontes.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Adfontes.Models.Repositories {

    public class NotebookRepository //: IAdfontesRepository<Notebook>
    {
        private ApplicationDbContext _context;

        public NotebookRepository(ApplicationDbContext context){
            this._context = context;
        }
        public async Task<Notebook> Add(Notebook entity)
        {
        
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == entity.AuthorId);
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
            var notebook = await this.GetById(entity.NotebookId);
            notebook.Title = entity.Title;
            notebook.UpdatedAt = DateTime.Now;

           await _context.SaveChangesAsync();

           return notebook;
        }

        public async Task<IEnumerable<Notebook>> GetAll()
        {
            var notebooks = await _context.Notebooks.ToListAsync();
            return notebooks;
        }

        public async Task<Notebook> GetById(int id)
        {
            var notebook = await _context.Notebooks.SingleOrDefaultAsync(n => n.NotebookId == id);
            return notebook;
        }

        public async Task<Notebook> Remove(int id)
        {
            var notebook = await _context.Notebooks.Where(n => n.NotebookId == id).Include(book => book.Notes).ThenInclude(notes => notes.Components).SingleOrDefaultAsync();
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
            
            return notebook;
        }        
    }
}