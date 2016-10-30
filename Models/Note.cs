using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Adfontes.Models
{
    [DataContract]
    public class Note
    {
        [DataMember]
        public int NoteId { get; set; }
        [DataMember]
        public string Title { get; set; }    
        public int NotebookId { get; set; }
        public Notebook Notebook { get; set; }
        public List<Component> Components {get; set; }
        
        [DataMember]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        [DataMember]
        public ApplicationUser Author { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
