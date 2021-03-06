﻿using System;

namespace View.Models {
    public class Request {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual User Author { get; set; }
    }
}