using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace View.ViewModels {
    public class RequestUpdateViewModel : IHasUserCollection {
        public IList<AuthorViewModel> Users { get; set; }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}