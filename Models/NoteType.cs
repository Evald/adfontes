using System.Collections.Generic;

namespace Adfontes.Models
{
    public class NoteType
    {
        public int NoteTypeId { get; set; }
        public string Title { get; set; }
        public List<Note> Notes { get; set; }
    }
}
