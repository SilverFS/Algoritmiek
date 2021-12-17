using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Group
    {
        public int group_id { get; set; }
        public bool HasChildren { get; set; } = false;
        public List<Guest> guests { get; set; }
    }
}
