namespace View.ViewModels {
    public class RequestViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}