﻿using System;
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
            int boxCount = random.Next(3, 4);

            // For the amount of boxes
            for (int i = 1; i <= boxCount; i++)
            {
                int seatCount = random.Next(3, 11);
                List<Row> rowList = new List<Row>();

                // For the amount of rows                
                for (int j = 1; j <= random.Next(2, 4); j++)
                {
                    List<Seat> seatList = new List<Seat>();
                    // For the amount of seats
                    for (int k = 1; k <= seatCount; k++)
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

        //Count number of seats
        public int CountAllSeats(List<Box> boxList)
        {
            int seatNumber = 0;
            foreach (Box box in boxList)
            {         
                foreach (Row row in box.rowList)
                {
                    foreach (Seat seat in row.seatList)
                    {
                        seatNumber++;
                    }
                }
            }
            return seatNumber;
        }

        //Check for enough seats in comparison to guests
        public bool CheckRoomSeats(List<Guest> guestList, List<Box> boxList)
        {
            if (guestList.Count > CountAllSeats(boxList))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Check which box has the most EMPTY seats in first row
        public List<Box> boxOrderList(List<Box> boxes)
        {
            List<Box> sorted = boxes.OrderByDescending(x => x.CountEmptyFirstSeats()).ToList();
            return sorted;
        }

        //Count all seats in first row of all boxes
        public int CountFirstRow(List<Box> boxes)
        {
            int allFirstSeats = 0;
            //Count all first seats in all first rows
            foreach (Box box in boxes)
            {
                int firstRow = box.rowList[0].seatList.Count;
                allFirstSeats += firstRow;

            }
            return allFirstSeats;
        }
    }
}
