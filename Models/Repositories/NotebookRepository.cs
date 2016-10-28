
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;

namespace Adfontes.Models.Repositories {

    public class NotebookRepository : IAdfontesRepository<Notebook>
    {
        private ApplicationDbContext _context;

        public NotebookRepository(ApplicationDbContext context){
            this._context = context;
        }
        public void Add(Notebook entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Notebook entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notebook> GetAll()
        {
            var notebooks = _context.Notebooks.AsEnumerable();
            return notebooks;
        }

        public Notebook GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }        
    }
}