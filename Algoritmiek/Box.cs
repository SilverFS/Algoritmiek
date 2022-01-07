using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Box
    {
        public int box_id { get; set; }
        public List<Row> rowList { get; set; }
        public List<Box> seatList { get; set; }

        public override string ToString()
        {
            return "Box " + box_id + " Rows in Box: " + rowList + " Seats in rows: " + seatList;
        }
    }
}
