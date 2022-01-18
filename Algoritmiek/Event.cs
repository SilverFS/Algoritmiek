using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using Algoritmiek.Containers;
using System.Linq;

namespace Algoritmiek
{
    public class Event
    {

        BoxContainer boxContainer = new BoxContainer();
        GroupContainer groupContainer = new GroupContainer();
        GuestContainer guestContainer = new GuestContainer();
        public List<Guest> guestList { get; set; }
        public List<Guest> singleGuests { get; set; }
        public List<Group> groupList { get; set; }
        public List<Box> boxList { get; set; }
        public Event()
        {
            guestList = guestContainer.CreateGuestList();
            groupList = groupContainer.FormGroups(guestList);
            singleGuests = guestContainer.SingleGuests(guestList);
            boxList = boxContainer.CreateBoxes();
        }


        //Check if group with largest amount of children can fit in that row of that box
        public void PlaceGroupsInBox()
        {
            List<Box> boxes = boxContainer.boxOrderList(boxList);
            foreach (Group group in groupList)
            {
                foreach (Box box in boxes)
                {
                    //Check seperately if Children en Adults both fit in the box
                    if (CheckIfChildrenFitInBox(box, group) && CheckIfAdultsFitInBox(box, group)) // == true
                    {
                        //if the group fits in the box, continue to next group.
                        //else, continue to next box.
                        PlaceChildrenInBox(box, group);
                        PlaceAdultsInBox(box, group);
                        group.isPlaced = true;
                        break;
                    }
                }
            }
            foreach (Guest guest in singleGuests)
            {
                foreach (Box box in boxes)
                {
                    if (box.CheckIfRemainingGuestsFitFirstRowInBox(box) && guest.isPlaced == false)
                    {
                        PlaceRemainingGuests(box, guest);
                        guest.isPlaced = true;
                        break;
                    }
                    if (box.CheckIfRemainingGuestsFitRestInBox(box) && guest.isPlaced == false)
                    {
                        PlaceRemainingGuests(box, guest);
                        guest.isPlaced = true;
                        break;
                    }
                }
            }
        }


        private void PlaceRemainingGuests(Box oneBox, Guest oneGuest)
        {
            bool isPlaced = false;
            for (int row = 0; row < oneBox.rowList.Count; row++)
            {
                if (isPlaced == true)
                {
                    break;
                }
                foreach (Seat seat in oneBox.rowList[row].seatList)
                {
                    if (seat.guest == null)
                    {
                        seat.guest = oneGuest;
                        isPlaced = true;
                        break;
                    }
                }
            }
        }


        //Check if first empty seats amount to children in group
        private bool CheckIfChildrenFitInBox(Box oneBox, Group oneGroup)
        {
            if (oneBox.CountEmptyFirstSeats() < oneGroup.children.Count)
            {
                return false;
            }
            return true;
        }

        //Place children of group in first row
        private void PlaceChildrenInBox(Box oneBox, Group oneGroup)
        {
            if (oneGroup.group_id > 0)
            {
                foreach (Guest child in oneGroup.children)
                {
                    foreach (Seat seat in oneBox.rowList[0].seatList)
                    {
                        if (seat.guest == null)
                        {
                            seat.guest = child;
                            break;
                        }
                    }
                }
            }
        }

        //Check if first empty seats amount to children in group
        private bool CheckIfAdultsFitInBox(Box oneBox, Group oneGroup)
        {
            if (oneBox.CountOtherEmptySeats() < oneGroup.adults.Count)
            {
                return false;
            }
            return true;
        }

        //Place adults of group in row
        private void PlaceAdultsInBox(Box oneBox, Group oneGroup)
        {
            if (oneGroup.group_id > 0)
            {
                foreach (Guest adult in oneGroup.adults)
                {
                    bool isPlaced = false;
                    for (int row = 1; row < oneBox.rowList.Count; row++)
                    {
                        if (isPlaced == true)
                        {
                            break;
                        }
                        foreach (Seat seat in oneBox.rowList[row].seatList)
                        {
                            if (seat.guest == null)
                            {
                                seat.guest = adult;
                                isPlaced = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
