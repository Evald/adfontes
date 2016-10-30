using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Adfontes.Models
{
    [DataContract]
    public class Notebook
    {
        [DataMember]
        public int NotebookId { get; set; }
        [DataMember]
        public string Title { get; set; }
        public List<Note> Notes { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
