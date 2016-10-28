
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;

namespace Adfontes.Models.Repositories {

    public class NoteRepository : IAdfontesRepository<Note>
    {
        private ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context){
            this._context = context;
        }
        public void Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Note entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }        
    }
}