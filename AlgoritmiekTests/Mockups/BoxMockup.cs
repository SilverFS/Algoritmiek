using Algoritmiek.Models;
using System;
using System.Collections.Generic;

namespace AlgoritmiekTests.Mockups
{
    public class BoxMockup
    {
        static Random random = new Random();

        public List<Box> CreateBoxes()
        {
            List<Box> boxList = new List<Box>();
            // counts specified, fixed amount
            int boxCount = 3; // = 3

            // For the amount of boxes
            for (int i = 1; i < boxCount; i++)
            {
                int seatCount = random.Next(3, 11);
                List<Row> rowList = new List<Row>();

                // For the amount of rows, fixed amount = 2             
                for (int j = 1; j < 2; j++)
                {
                    List<Seat> seatList = new List<Seat>();
                    // For the amount of seats
                    for (int k = 1; k < seatCount; k++)
                    {
                        seatList.Add(new Seat
                        {
                            seat_id = k,
                            row_id = j,
                            box_id = i,
                        });
                    }
                    rowList.Add(new Row
                    {
                        row_id = j,
                        box_id = i,
                        seatList = seatList,
                    });
                }
                boxList.Add(new Box
                {
                    box_id = i,
                    rowList = rowList,
                });
            }
            return boxList;
        }
    }
}
