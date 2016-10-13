using System.Collections.Generic;

namespace Adfontes.Models{

    public interface INoteRepository{
        IEnumerable<Notebook> GetNotebooks();
        Notebook GetNotebook(int id);
        void RemoveNotebook(int id);
        Notebook UpdateNotebook(Notebook notebook);
        IEnumerable<Note> GetNotes(int notebookId);
        Note GetNote(int id);
        void RemoveNote(int id);
        Note UpdateNote(Note note);
        void AddNote(int notebookId, Note note);
        void AddNotebook(Notebook notebook);
    }
}