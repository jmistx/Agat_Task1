using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace View.ViewModels {
    public class RequestCreateViewModel {
        public IList<AuthorViewModel> Users { get; set; }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Created at")]
        public string DateCreated { get; set; }
        [Required]
        [DisplayName("Author")]
        public AuthorViewModel Author { get; set; }
    }
}