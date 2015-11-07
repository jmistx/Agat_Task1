using System.Collections.Generic;

namespace View.ViewModels {
    public interface IHasUserCollection {
        IList<AuthorViewModel> Users { get; set; }
    }
}