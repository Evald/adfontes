using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adfontes.Models
{
    public class Notebook
    {
        public int NotebookId { get; set; }
        public string Title { get; set; }
        public List<Note> Notes { get; set; }
        
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
