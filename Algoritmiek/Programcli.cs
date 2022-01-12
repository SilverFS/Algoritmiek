using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using Spectre.Console;
using System.Threading;

namespace Algoritmiek
{
    class Programcli
    {
        static void Main(string[] args)
        {
            Event sortEvent = new Event();
            Console.Title = "Event Calculator";
            // Synchronous and fun progress bar :)
            AnsiConsole.Progress().Start(ctx =>
            {
                // Define tasks
                var task1 = ctx.AddTask("[green]Generating guests:[/]");
                var task2 = ctx.AddTask("[green]Calculating box-space:[/]");

                while (!ctx.IsFinished)
                {
                    //Increment
                    task1.Increment(8.5);
                    task2.Increment(7.5);
                    Thread.Sleep(180);
                }
            });
            AnsiConsole.Markup("[green]DONE![/]\n");
            Thread.Sleep(800);
            AnsiConsole.Markup($"\nCheck for enough seats in comparison to guests: [orange3 slowblink]" +
                $"{ sortEvent.CheckRoomSeats() }[/]. It counts [teal slowblink]{ sortEvent.CountAllSeats() }[/] seats.\n");

            sortEvent.PlaceChildrenInRow();
            DisplayAll(sortEvent.boxList, sortEvent.groupList, sortEvent.guestList, sortEvent);
            Console.Read();
        }

        private static void DisplayAll(List<Box> boxList, List<Group> groupList, List<Guest> guestList, Event sortEvent)
        {
            AnsiConsole.Markup($"[bold]**The Total [green]passed[/] guests: [/][teal slowblink]{ guestList.Count }[/]");
            AnsiConsole.Markup($"\n**The Total  groups amount to: [teal slowblink]{ groupList.Count - 1 }[/]\n\n");
            AnsiConsole.Markup("\n[green bold underline]GUEST LIST[/]: \n");

            AnsiConsole.Markup("\nBelow the box setup: \n");
            AnsiConsole.Markup("\n[green bold underline]BOX LIST[/]: \n");
            //Add Tree root
            var root = new Tree("[red bold]Event[/]").Style("red");
            AnsiConsole.Markup($"Count of all first seats in all rows: [teal slowblink]{ sortEvent.CountFirstRow() }[/] \n");
            AnsiConsole.Markup("You have a total of: [teal slowblink]" + boxList.Count + "[/] boxes! \n");
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
                        if (seats.guest == null)
                        {
                            singleRow.AddNode("[lime bold]Seat [/]" + seats.seat_id + " -> guest: " + seats.guest + "");
                        }
                        else
                        {
                            singleRow.AddNode("[lime bold]Seat [/]" + seats.seat_id + " -> guest: " + seats.guest.guest_id + " --> adult: " + seats.guest.IsAdult + "");
                        }

                    }
                }
            }
            AnsiConsole.Write(root);

            var table = new Table();
            table.Title("[red]All Guests[/]");

            //table manners
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

                foreach (var guest in item.adults)
                {
                    singleGroup.AddNode("[blue bold]Adult ID: [/]" + guest.guest_id + "");
                }
            }
            AnsiConsole.Write(root2);
            AnsiConsole.Markup("\nPress Enter to [red underline]EXIT[/]:");
        }
    }
}
