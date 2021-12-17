using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Guest
    {
        public int guest_id { get; set; }
        public bool OnTime { get; set; } = true;
        public bool IsAdult { get; set; } = true;
        public int group_id { get; set; }
    }
}
