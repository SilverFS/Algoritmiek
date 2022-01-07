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
        public List<Seat> seats { get; set; }
        public int totalSeats { get; set; }


        // Pre-defined local variables
        static Random random = new Random();
        static int guestCount = random.Next(11, 151);
        int seatCount = random.Next(11, 151);




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
            List<Row> rowList = new List<Row>();
            List<Seat> seatList = new List<Seat>();
            // counts specified
            int boxCount = random.Next(2, 5);
            int rowCount = random.Next(1, 3);
            int seatCount = random.Next(3, 10);

            // For the amount of boxes
            for (int i = 1; i < boxCount; i++)
            {

                // For the amount of rows
                for (int j = 1; j < rowCount; j++)
                {
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
                    });
                }
                boxList.Add(new Box
                {
                    box_id = i,
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
