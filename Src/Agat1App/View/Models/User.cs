namespace View.Models {
    public class User {
        virtual public int Id { get; set; }
        virtual public string FirstName { get; set; }
        virtual public string LastName { get; set; }
        public Address Address { get; set; }
    }
}