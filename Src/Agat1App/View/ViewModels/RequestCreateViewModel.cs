using System.Collections.Generic;

namespace View.ViewModels {
    public class RequestCreateViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public AuthorViewModel Author { get; set; }
        public IList<AuthorViewModel> Users { get; set; }
    }
}