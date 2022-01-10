using Algoritmiek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmiekTests.Mockups
{
    public class GuestMockup
    {
        static Random random = new Random();
        public readonly int guestCount = 101;
        public List<Guest> guestListTest = new List<Guest>();
        static double trueProbability = 0.8;
        public List<Guest> CreateGuests()
        {


            for (int i = 0; i < guestCount; i++)
            {
                guestListTest.Add(new Guest
                {
                    guest_id = i,
                    OnTime = random.NextDouble() < trueProbability,
                    IsAdult = Convert.ToBoolean(random.Next(2)),
                    group_id = random.Next(0, 9),
                });
            }
            return guestListTest;
        }

        public List<Box> CreateBoxes()
        {
            List<Box> boxList = new List<Box>();
            // counts specified
            int boxCount = 3; // = 3

            // For the amount of boxes
            for (int i = 1; i < boxCount; i++)
            {
                int seatCount = random.Next(3, 11);
                List<Row> rowList = new List<Row>();

                // For the amount of rows = 2             
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
