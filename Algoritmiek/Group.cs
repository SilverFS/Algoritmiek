using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Group
    {
        public int group_id { get; set; }
        public int children { get; set; }
        public List<Guest> guestsInGroup { get; set; }

        public override string ToString()
        {
            return "Group " + group_id + ": " + "Children: " + children + " - " + guestsInGroup;
        }
    }
}
