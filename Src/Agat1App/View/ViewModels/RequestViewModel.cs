using System.ComponentModel;

namespace View.ViewModels {
    public class RequestViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        [DisplayName("Created at")]
        public string DateCreated { get; set; }
        [DisplayName("Author")]
        public AuthorViewModel Author { get; set; }
    }
}