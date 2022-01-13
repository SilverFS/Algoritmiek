using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek.Models
{
    public class Group
    {
        public int group_id { get; set; }
        public List<Guest> children { get; set; }
        public List<Guest> adults { get; set; }
        public bool isPlaced { get; set; }

        public override string ToString()
        {
            return "Group " + group_id + ": " + "Children: " + children + " - " + adults;
        }
    }
}
