﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public class Organizer : User
    {
        public int Rating { get; set; }

        public Organizer(int id, string username, string password, string firstName, string lastName)
            : base(id, username, password, firstName, lastName)
        {
        }

        public Organizer(int id, string username, string password, string firstName, string lastName, int rating)
            : this(id, username, password, firstName, lastName)
        {
            Rating = rating;
        }
    }
}
