using System;
using System.ComponentModel.DataAnnotations;

namespace Adfontes.Models.ViewModels {

    public class NotebookAddViewModel{

        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorId { get; set; }
    }

    // public class NotebookGetViewModel{

    //     [Required]
    //     public string Title { get; set; }
    //     [Required]
    //     public string AuthorName { get; set; }

    //     public DateTime CreatedAt { get; set; }
    //     public DateTime UpdatedAt { get; set; }
    //     [JsonIgnore]
    //     public List<Notes> Notes { get; set; }
    // }
}