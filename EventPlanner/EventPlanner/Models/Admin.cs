using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public class Admin : User
    {

        public Admin(string username, string password, string firstName, string lastName)
            : base(username, password, firstName, lastName)
        {
        }
    }
}
