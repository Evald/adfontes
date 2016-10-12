
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adfontes.Models {

    public class NoteRepository : INoteRepository
    {
        private ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context){
            this._context = context;
        }
        public Note GetNote(int id)
        {
            return _context.Notes.Single(n => n.NoteId == id);
        }

        public Notebook GetNotebook(int id)
        {
            return _context.Notebooks.Single(n => n.NotebookId == id);
        }

        public IEnumerable<Notebook> GetNotebooks()
        {
            return _context.Notebooks.ToList();
        }

        public IEnumerable<Note> GetNotes(int notebookId)
        {
            return _context.Notes.Where(n => n.NotebookId == id).ToList();
        }

        public Note RemoveNote(int id)
        {
           Note item = _context.Notes.Single(n => n.NoteId == id);
           _context.Remove(item);
           _context.SaveChanges();
           return  item;
        }

        public Notebook RemoveNotebook(int id)
        {
            Notebook item = _context.Notebooks.Single(n => n.NotebookId == id);
           _context.Remove(item);
           _context.SaveChanges();
           return  item;
        }

        public Note UpdateNote(Note note)
        {
            Note item = _context.Update(note);
           _context.SaveChanges();
           return  item;
        }

        public Notebook UpdateNotebook(Notebook notebook)
        {
            Notebook item = _context.Update(notebook);
           _context.SaveChanges();
           return  item;
        }
    }
}