using System;

namespace View.Models {
    public class Request {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public User Author { get; set; }
    }
}