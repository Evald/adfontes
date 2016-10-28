using System.ComponentModel.DataAnnotations.Schema;

namespace Adfontes.Models
{
    public class Component
    {
        public int ComponentId { get; set; }
        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }
        public string Content { get; set; }
    }
}
