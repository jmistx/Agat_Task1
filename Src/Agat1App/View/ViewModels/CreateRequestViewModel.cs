using System.Collections.Generic;

namespace View.ViewModels {
    public class CreateRequestViewModel {
        public int Id { get; set; }
        public string Description { get; set; }
        public RequestUserViewModel Author { get; set; }
        public IList<RequestUserViewModel> Users { get; set; }
    }
}