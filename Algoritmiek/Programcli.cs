using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using Algoritmiek.Containers;
using System.Linq;
using Spectre.Console;

namespace Algoritmiek
{

    //Known issue: new menu entry gives new data.
    class Programcli
    {
        static void Main(string[] args)
        {
            Event sortEvent = new Event();
            BoxContainer boxContainer = new BoxContainer();
            GroupContainer groupContainer = new GroupContainer();
            GuestContainer guestContainer = new GuestContainer();
            List<Box> boxList = boxContainer.CreateBoxes();
            List<Guest> guestList = guestContainer.CreateGuestList();
            List<Group> groupList = groupContainer.FormGroups(guestList);

            Console.Title = "Event Calculator";
            AnsiConsole.Markup($"Check for enough seats in comparison to guests: [orange3 slowblink]{ sortEvent.CheckRoomSeats() }[/]. " +
                $"It counts [teal slowblink]{ sortEvent.CountAllSeats() }[/] seats.\n");
            DisplayAll(boxList, groupList, guestList);
            Console.WriteLine($"\nAll first seats in all rows: { sortEvent.CheckEmptyFirstRow() } \n");


            Console.Read();
        }


        private static void DisplayAll(List<Box> boxList, List<Group> groupList, List<Guest> guestList)
        {
            AnsiConsole.Markup("[bold]**The Total [green]passed[/] guests: [/][teal slowblink]" + guestList.Count + "[/]\n");
            AnsiConsole.Markup($"**The Total  groups amount to: {groupList.Count}\n\n");
            AnsiConsole.Markup("\n[green bold underline]GUEST LIST[/]: \n");


            var table = new Table();
            table.Title("[red]All Guests[/]");


            table.Border(TableBorder.Simple);
            table.BorderColor(Color.Orange3);
            //var printGuests = guestContainer.CreateGuestList();
            int count = guestList.Count;
            var last = guestList.FindLast;
            //Add columns
            table.AddColumn("Guest");
            table.AddColumn("On Time");
            table.AddColumn("Is Adult");
            table.AddColumn("Group Number");
            foreach (var item in guestList)
            {
                //Add rows
                table.AddRow(item.guest_id + "", item.OnTime + "", item.IsAdult + "", item.group_id + "");
            }

            AnsiConsole.Write(table);
            AnsiConsole.Markup("\n[italic]* This table is ordered by group id\n** This userlist is seperate data for boxes.\n   This means this table is completely irrelevant.[/]\n\n\n");

            AnsiConsole.Markup("\n[green bold underline]GROUP LIST[/]: \n\n");
            //Add Tree root for group list
            var root2 = new Tree("[red bold]Event[/]").Style("red");


            //Add columns
            foreach (var item in groupList)
            {
                var singleGroup = root2.AddNode("[orangered1 bold]group id: [/]" + item.group_id + "");
                foreach (var child in item.children)
                {
                    singleGroup.AddNode("[blue bold]Child ID: [/]" + child.guest_id + "");
                }

                foreach (var guest in item.guestsInGroup)
                {
                    singleGroup.AddNode("[blue bold]Adult ID: [/]" + guest.guest_id + "");
                }
            }
            AnsiConsole.Write(root2);
            AnsiConsole.Markup("\nBelow the box setup: \n");



            AnsiConsole.Markup("\n[green bold underline]BOX LIST[/]: \n");
            //Add Tree root
            var root = new Tree("[red bold]Event[/]").Style("red");

            AnsiConsole.Markup("\n You have a total of: [teal slowblink]" + boxList.Count + "[/] boxes! \n");
            AnsiConsole.Markup("_____________________\n\n");
            //Add nodes in loops
            foreach (var boxes in boxList)
            {
                var singleBox = root.AddNode("[orangered1 bold]Box [/]" + boxes.box_id);
                foreach (var rows in boxes.rowList)
                {
                    var singleRow = singleBox.AddNode("[blue bold]Row [/]" + rows.row_id);
                    foreach (var seats in rows.seatList)
                    {
                        singleRow.AddNode("[lime bold]Seat [/]" + seats.seat_id + " -> guest: " + guestList.Count);
                    }
                }
            }
            AnsiConsole.Write(root);
            AnsiConsole.Markup("\nPress Enter to continue:");
        }
    }
}
