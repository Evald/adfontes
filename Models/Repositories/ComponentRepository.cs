
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;

namespace Adfontes.Models.Repositories {

    public class ComponentRepository : IAdfontesRepository<Component>
    {
        private ApplicationDbContext _context;

        public ComponentRepository(ApplicationDbContext context){
            this._context = context;
        }
        public void Add(Component entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Component entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Component> GetAll()
        {
            throw new NotImplementedException();
        }

        public Component GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }        
    }
}