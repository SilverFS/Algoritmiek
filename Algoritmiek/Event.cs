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


        // Defines Random
        static Random random = new Random();
        // The total amount of guests between 25 and 101.
        static readonly int guestCount = random.Next(25, 101);
        // Used for percentage draws
        // In this case, there is an 80% chance of being true
        static double trueProbability = 0.8;





        // Create a random number of guests with groups
        public List<Guest> CreateGuests()
        {
            guests = new List<Guest>();

            for (int i = 1; i < guestCount; i++)
            {
                guests.Add(new Guest
                {
                    guest_id = i,
                    OnTime = random.NextDouble() < trueProbability,
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
