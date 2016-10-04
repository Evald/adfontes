using System.ComponentModel.DataAnnotations.Schema;

namespace Adfontes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public int NoteTypeId { get; set; }
        public NoteType NoteType { get; set; }
        public int NotebookId { get; set; }
        public Notebook Notebook { get; set; }
        
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
