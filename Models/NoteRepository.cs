
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
            return _context.Notes.Where(n => n.NotebookId == notebookId).ToList();
        }

        public void RemoveNote(int id)
        {
           Note item = _context.Notes.Single(n => n.NoteId == id);
           _context.Remove(item);
           _context.SaveChanges();
        }

        public void RemoveNotebook(int id)
        {
            Notebook item = _context.Notebooks.Single(n => n.NotebookId == id);
           _context.Remove(item);
           _context.SaveChanges();
        }

        public Note UpdateNote(Note note)
        {
            var item = _context.Notes.Single(n => n.NoteId == note.NoteId);
            item.Title = note.Title;

            var type = _context.NoteTypes.Single(n => n.NoteTypeId == note.NoteTypeId);
            if (type != null)
            {
                 type.Notes.Add(item);
            }else
            {
                item.NoteTypeId = 0;
            }           

           _context.SaveChanges();
           return  item;
        }

        public Notebook UpdateNotebook(Notebook notebook)
        {
            Notebook item = _context.Notebooks.Single(n => n.NotebookId == notebook.NotebookId);
            item.Title = notebook.Title;
           _context.SaveChanges();
           return  item;
        }

         public void AddNote(int notebookId, Note note){
            var notebook = this.GetNotebook(notebookId);
            notebook.Notes.Add(note);
            var noteItem = _context.Notes.Add(note);
            _context.SaveChanges();

         }
        public void AddNotebook(Notebook notebook){
            var notebookItem = _context.Notebooks.Add(notebook);
            _context.SaveChanges();
        }
    }
}