using System.Collections.Generic;

namespace View.Models {
    public class User {
        virtual public int Id { get; set; }
        virtual public string FirstName { get; set; }
        virtual public string LastName { get; set; }
        virtual public Address Address { get; set; }
        virtual public ICollection<Request> Requests { get; set; }
    }
}