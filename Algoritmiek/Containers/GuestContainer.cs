using Algoritmiek.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmiek.Containers
{
    public class GuestContainer
    {
        public List<Guest> CreateGuestList()
        {
            Random random = new Random();
            List<Guest> guests = new List<Guest>();
            // The total amount of guests between 25 and 101
            int guestCount = random.Next(35, 101);
            // Used for percentage draws. In this case, there is an 80% chance of it being true
            double trueProbability = 0.8;

            for (int i = 1; i < guestCount; i++)
            {
                guests.Add(new Guest
                {
                    guest_id = i,
                    OnTime = random.NextDouble() < trueProbability,
                    IsAdult = Convert.ToBoolean(random.Next(2)),
                    group_id = random.Next(0, 5),
                });
            }

            //Removes guest if guest is too late
            for (int i = 0; i < guests.Count; i++)
            {
                if (guests[i].OnTime == false)
                {
                    guests.RemoveAt(i);
                    i--;
                }
            }
            guests = guests.OrderBy(x => x.group_id).ToList();
            return guests;
        }

        public List<Guest> SingleGuests(List<Guest> guestList)
        {
            List<Guest> singleGuests = new();
            foreach (var guest in guestList)
            {
                if (guest.group_id == 0 && guest.IsAdult == true)
                {
                    singleGuests.Add(new Guest
                    {
                        guest_id = guest.guest_id,
                        group_id = guest.group_id,
                        IsAdult = true,
                        OnTime = true,
                    });
                }
            }
            return singleGuests;
        }
    }
}

