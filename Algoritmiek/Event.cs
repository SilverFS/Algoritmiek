using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
    public class Event
    {
        public List<Box> boxes { get; set; }
        public List<Guest> guests { get; set; }
        public int totalSeats { get; set; }


        public List<Guest> CreateGuests()
        {
            guests = new List<Guest>();
            Random random = new Random();
            for (int i = 1; i < 101; i++)
            {
                guests.Add(new Guest
                {
                    guest_id = i,
                    OnTime = Convert.ToBoolean(random.Next(2)),
                    IsAdult = Convert.ToBoolean(random.Next(2)),
                    group_id = 0,
                });
            }
            return guests;
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
