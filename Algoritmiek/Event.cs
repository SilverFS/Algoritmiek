using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algoritmiek
{
    public class Event
    {
        public List<Box> boxList { get; set; }
        public List<Guest> guests { get; set; }
        public List<Group> groups { get; set; }
        public int totalSeats { get; set; }


        // Pre-defined local variables
        static Random random = new Random();
        static int guestCount = random.Next(11, 151);




        // Create a random number of guests with groups
        public List<Guest> CreateGuests()
        {
            guests = new List<Guest>();

            for (int i = 1; i < guestCount; i++)
            {
                guests.Add(new Guest
                {
                    guest_id = i,
                    OnTime = Convert.ToBoolean(random.Next(2)),
                    IsAdult = Convert.ToBoolean(random.Next(2)),
                    group_id = random.Next(0, 9),
                });
            }
            // Order by group_id -> ascending 
            guests = guests.OrderBy(x => x.group_id).ToList();
            return guests;
        }








        public List<Box> CreateBoxes()
        {
            List<Box> boxList = new List<Box>();
            // counts specified
            int boxCount = random.Next(2, 6);

            // For the amount of boxes
            for (int i = 0; i < boxCount; i++)
            {
                int seatCount = random.Next(3, 11);
                List<Row> rowList = new List<Row>();

                // For the amount of rows                
                for (int j = 0; j < random.Next(1, 4); j++)
                {
                    List<Seat> seatList = new List<Seat>();
                    // For the amount of seats
                    for (int k = 0; k < seatCount; k++)
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














        //public List<Box> makeBox()
        //{
        //    var listOfBoxes = new List<int>();
        //    Random rnd = new Random();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        listOfBoxes.Add(rnd.Next(10));
        //    }
        //    return listOfBoxes;


        //    for (int i = 1; i < 3; i++)
        //    {
        //        //make the areas
        //        Box box = new Box(i, rnd.Next(2, 6));
        //        boxList.Add(box);
        //    }





        //    var listOfRows = new List<int>();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        listOfRows.Add(rnd.Next(3));
        //    }

        //}
    }
}
