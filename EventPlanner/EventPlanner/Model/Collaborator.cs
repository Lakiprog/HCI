using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Model
{
    public enum CollaboratorType { FLOWER_SHOP, RESTAURANT, BALLOONS, DRINK_STORE }
    public class Collaborator
    {
        public string Name { get; set; }
        public CollaboratorType Type { get; set; }
        public string Address { get; set; }

        public Collaborator(string name, CollaboratorType type, string address)
        {
            Name = name;
            Type = type;
            Address = address;
        }
    }
}
