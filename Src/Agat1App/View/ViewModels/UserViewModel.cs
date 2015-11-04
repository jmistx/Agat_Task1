using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressViewModel Address { get; set; }
    }
}