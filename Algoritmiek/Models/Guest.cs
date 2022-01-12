using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek.Models
{
    public class Guest
    {
        public int guest_id { get; set; }
        public bool OnTime { get; set; } = true;
        public bool IsAdult { get; set; } = true;
        public int group_id { get; set; }


        public override string ToString()
        {
            return "Guest " + guest_id + ": " + "On Time: " + OnTime + " - " + "Is Adult: " + IsAdult + " - " + "Group ID: " + group_id;
        }
    }
}