using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek.Models
{
    public class Box
    {
        public int box_id { get; set; }
        public List<Row> rowList { get; set; }

        //Count all empty seats in the first row of the box
        public int CountEmptyFirstSeats()
        {
            int openSeatsInFirstRow = 0;
            for (int i = 0; i < rowList[0].seatList.Count; i++)
            {
                if (rowList[0].seatList[i].guest == null)
                {
                    openSeatsInFirstRow++;
                }
            }
            return openSeatsInFirstRow;
        }

        //Count all empty seats in the other rows of the box
        public int CountOtherEmptySeats()
        {
            int openSeatsInOtherRows = 0;
            for (int i = 1; i < rowList.Count; i++)
            {
                foreach (Seat seat in rowList[i].seatList)
                {
                    if (seat.guest == null)
                    {
                        openSeatsInOtherRows++;
                    }
                }
            }
            return openSeatsInOtherRows;
        }
    }
}
