using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Row
    {
        public int row_id { get; set; }
        public int box_id { get; set; }
        public List<Seat> seats { get; set; }
    }
}
