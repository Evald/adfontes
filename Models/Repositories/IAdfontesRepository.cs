using System;
using System.Collections.Generic;

namespace Adfontes.Models.Repositories {

    public interface IAdfontesRepository<TEnity> {
        IEnumerable<TEnity> GetAll ();
        TEnity GetById (int id);
        void Remove (int id);
        void Add (TEnity entity);
        void Edit(TEnity entity);    
    }
}