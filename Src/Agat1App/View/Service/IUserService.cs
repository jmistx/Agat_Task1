using System.Collections.Generic;
using View.ViewModels;

namespace View.Service {
    public interface IUserService {
        IList<UserViewModel> GetAllUsers();
        UserViewModel Save(UserViewModel vm);
        UserViewModel GetUser(int id);
        void Delete(int id);
    }
}