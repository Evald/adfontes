
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
        public async Task<Notebook> Add(NotebookAddViewModel entity)
        {
        
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == entity.AuthorId);
            var notebook = _context.Notebooks.Add(new Notebook {
               Title = entity.Title,
               Author = author,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return notebook.Entity;
        }

        public async Task Edit(Notebook entity)
        {
            //await _context.Notebooks.Update(entity);
            throw new NotImplementedException();
        }

        public async Task<List<Notebook>> GetAll()
        {
            var notebooks = await _context.Notebooks.ToListAsync();
            return notebooks;
        }

        public async Task<Notebook> GetById(int id)
        {
            var notebook = await _context.Notebooks.SingleOrDefaultAsync(n => n.NotebookId == id);
            return notebook;
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }        
    }
}