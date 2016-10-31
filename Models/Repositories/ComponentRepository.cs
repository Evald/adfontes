
using System;
using System.Collections.Generic;
using System.Linq;
using Adfontes.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Adfontes.Models.Repositories {

    public class ComponentRepository
    {
        private ApplicationDbContext _context;

        public ComponentRepository(ApplicationDbContext context){
            this._context = context;
        }

        public async Task<Component> Add(Component entity)
        {
            // Gets the component type associated with the component.
            var componentType = await _context.ComponentTypes.SingleOrDefaultAsync(c => c.ComponentTypeId == entity.ComponentTypeId);

            // Gets the components parent note.
            var parentNote = await _context.Notes.SingleOrDefaultAsync(n => n.NoteId == entity.NoteId);

            //Add a new component.
            var component = _context.Components.Add(new Component {
                 ComponentType = componentType,
                 Note = parentNote,
                 Content = entity.Content
            }).Entity;
            await _context.SaveChangesAsync();

            return component;
        }

        public async Task<Component> Edit(Component entity)
        {
            // Gets resource using provided id and updates allowed properties.
            var component = await _context.Components.Where(c => c.ComponentId == entity.ComponentId).Include(t => t.Note).SingleOrDefaultAsync();
            // Gets the component type associated with the component.
            var componentType = await _context.ComponentTypes.SingleOrDefaultAsync(c => c.ComponentTypeId == entity.ComponentTypeId);


            component.Content = entity.Content;
            component.ComponentType = componentType;
            //Sets the UpdatedAt property of the parent note
            component.Note.UpdatedAt = DateTime.Now;

           await _context.SaveChangesAsync();

           return component;
        }

        public async Task<IEnumerable<Component>> GetAll()
        {
            // Gets and returns all resources as an IEnumerable.           
            var component = await _context.Components.Include(t => t.ComponentType).ToListAsync();
            return component;
        }

        public async Task<IEnumerable<Component>> GetAllByParentId(int parentId)
        {
            // Gets and returns all resources associated with parent as an IEnumerable.           
            var component = await _context.Components.Where(c => c.NoteId == parentId).Include(t => t.ComponentType).ToListAsync();
            return component;
        }

        public async Task<Component> GetById(int id)
        {
             // Gets the resource using provided id.
            var component = await _context.Components.Where(c => c.ComponentId == id).Include(t => t.ComponentType).SingleOrDefaultAsync();
            return component;
        }

        public async Task<Component> Remove(int id)
        {
            // Deletes resource using provided id
            var component = await _context.Components.Where(c => c.ComponentId == id).Include(t => t.ComponentType).SingleAsync();
            _context.Components.Remove(component);

            await _context.SaveChangesAsync();
            
            return component;
        }
    }
}