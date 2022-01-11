using Algoritmiek.Models;
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
    }
}
