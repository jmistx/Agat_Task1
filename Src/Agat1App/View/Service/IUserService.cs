using System.Collections.Generic;
using View.ViewModels;

namespace View.Service {
    public interface IUserService {
        IList<UserViewModel> GetAllUsers();
    }
}