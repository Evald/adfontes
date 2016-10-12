using System.Collections.Generic;

namespace Adfontes.Models{

    public interface INoteRepository{
        IEnumerable<Notebook> GetNotebooks();
        Notebook GetNotebook(int id);
        Notebook RemoveNotebook(int id);
        Notebook UpdateNotebook(Notebook notebook);
        IEnumerable<Note> GetNotes(int notebookId);
        Note GetNote(int id);
        Note RemoveNote(int id);
        Note UpdateNote(Note note);
        Note AddNote(int notebookId, Note note);
        Notebook AddNotebook(Notebook notebook);
    }
}