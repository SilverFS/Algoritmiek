using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek.Containers
{
    public class BoxContainer
    {
        // Defines Random
        static Random random = new Random();

        public List<Box> CreateBoxes()
        {
            List<Box> boxList = new List<Box>();
            // counts specified
            int boxCount = random.Next(3, 8);

            // For the amount of boxes
            for (int i = 1; i < boxCount; i++)
            {
                int seatCount = random.Next(3, 11);
                List<Row> rowList = new List<Row>();

                // For the amount of rows                
                for (int j = 1; j < random.Next(2, 4); j++)
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
                            //guest = guest_id,

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
