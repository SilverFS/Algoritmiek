using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Seat
    {
        public int seat_id { get; set; }
        public int row_id { get; set; }
        public int box_id { get; set; }
        public Guest guest { get; set; }
    }
}
