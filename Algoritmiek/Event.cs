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
        List<Guest> guestList;
        List<Group> groupList;
        List<Box> boxList;
        public Event()
        {
            guestList = guestContainer.CreateGuestList();
            groupList = groupContainer.FormGroups(guestList);
            boxList = boxContainer.CreateBoxes();
        }


        //Count number of seats
        public int CountAllSeats()
        {
            int seatNumber = 0;
            foreach (var box in boxList)
            {
                foreach (var row in box.rowList)
                {
                    foreach (var seat in row.seatList)
                    {
                        seatNumber++;
                    }
                }
            }
            return seatNumber;
        }
        //Check for enough seats in comparison to guests
        public bool CheckRoomSeats()
        {

            if (guestList.Count > CountAllSeats())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Count all children per group
        public int CountChildrenInGroup()
        {
            int allChildrenGroup = 0;
            //Count all first seats in all first rows
            foreach (var group in groupList)
            {
                var children = group.children.Count;
                allChildrenGroup += children;
            }
            return allChildrenGroup;
        }

        //Check availability of first row
        public int CheckEmptyFirstRow()
        {
            int allFirstSeats = 0;
            //Count all first seats in all first rows
            foreach (var box in boxList)
            {
                var firstRow = box.rowList[0].seatList.Count;
                allFirstSeats += firstRow;

            }
            return allFirstSeats;
        }


        //Place children of group in first row
        public void PlaceChildrenInRow()
        {

        }


        //Check availability of leftover rows
        public void CheckEmptyOtherRows()
        {

        }


        //Place leftover group in leftover rows
        public void PlaceAdultsInRows()
        {

        }


        //Place groups in boxes
        public void PlaceGroups(List<Group> groupList, List<Box> boxList)
        {
            for (int group = 0; group < groupList.Count; group++)
            {
                for (int box = 0; box < boxList.Count; box++)
                {
                    //something
                }
            }
        }
    }
}
