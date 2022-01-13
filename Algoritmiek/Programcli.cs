using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using Spectre.Console;
using System.Threading;
using Algoritmiek.Containers;

namespace Algoritmiek
{
    class Programcli
    {
        static void Main(string[] args)
        {
            Event sortEvent = new();
            BoxContainer boxContainer = new();
            //It happens here!
            sortEvent.PlaceGroupsInBox();
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

            //Loop in MainMenu
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(sortEvent.guestList, sortEvent.groupList);
            }
            AnsiConsole.Markup("[invert bold orchid2]Goodbye![/]\n");
            Thread.Sleep(200);
            return;

            //Main Menu
            bool MainMenu(List<Guest> guestList, List<Group> groupList)
            {

                AnsiConsole.Markup("\n[invert bold green]*Welcome to the event calculator!*[/] \n\n");
                AnsiConsole.Markup($"[bold]- The total [green]passed[/] guests: [/][teal slowblink]{ guestList.Count }[/]\n");
                AnsiConsole.Markup($"[bold]- The total groups amount to: [/][teal slowblink]{ groupList.Count - 1 }[/]\n\n");
                AnsiConsole.Markup($"\nCheck for enough seats in comparison to guests: [orange3 slowblink]" +
                    $"{ sortEvent.CheckRoomSeats() }[/]. It counts [teal slowblink]{ sortEvent.CountAllSeats() }[/] seats.\n");
                AnsiConsole.Markup("\nChoose an option:\n");
                AnsiConsole.Markup("[yellow]1[/]) Displays Box data\n");
                AnsiConsole.Markup("[yellow]2[/]) Displays a table of guests\n");
                AnsiConsole.Markup("[yellow]3[/]) Displays a table of groups\n");
                AnsiConsole.Markup("\nType '[red]exit[/]' to exit the program \n");
                AnsiConsole.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowBoxes(sortEvent.boxList, sortEvent.groupList, sortEvent.guestList, sortEvent, boxContainer);
                        Console.ReadLine();
                        return true;
                    case "2":
                        ShowGuests(sortEvent.groupList, sortEvent.guestList);
                        Console.ReadLine();
                        return true;
                    case "3":
                        ShowGroups(sortEvent.groupList, sortEvent.guestList);
                        Console.ReadLine();
                        return true;
                    case "exit":
                        return false;
                    default:
                        return true;
                }
            }

            void ShowBoxes(List<Box> boxList, List<Group> groupList, List<Guest> guestList, Event sortEvent, BoxContainer boxContainer)
            {
                AnsiConsole.Markup($"\n[bold]**The Total [green]passed[/] guests: [/][teal slowblink]{ guestList.Count }[/]\n");
                AnsiConsole.Markup($"\n**The Total  groups amount to: [teal slowblink]{ groupList.Count - 1 }[/]\n");
                AnsiConsole.Markup("\nBelow the box setup: \n");
                AnsiConsole.Markup("\n[green bold underline]BOX LIST[/]: \n");
                //Add Tree root
                var root = new Tree("[red bold]Event[/]").Style("red");
                AnsiConsole.Markup($"Count of all first seats in all rows: [teal slowblink]{ boxContainer.CountFirstRow(boxList) }[/] \n");
                AnsiConsole.Markup("You have a total of: [teal slowblink]" + boxList.Count + "[/] boxes! \n");
                AnsiConsole.Markup("_____________________\n\n");
                //Add nodes in loops
                foreach (var boxes in boxList)
                {
                    var singleBox = root.AddNode($"[orangered1 bold]Box [/] { boxes.box_id }");
                    foreach (var rows in boxes.rowList)
                    {
                        var singleRow = singleBox.AddNode($"[blue bold]Row [/] { rows.row_id }");
                        foreach (var seats in rows.seatList)
                        {
                            if (seats.guest == null)
                            {
                                singleRow.AddNode($"[lime bold]Seat [/] { seats.seat_id } -> [grey]Empty[/] ");
                            }
                            else
                            {
                                singleRow.AddNode($"[lime bold]Seat [/] { seats.seat_id } -> [gold3_1]guest[/]: { seats.guest.guest_id } --> [maroon]group[/]: { seats.guest.group_id } --> [fuchsia]adult[/]: { seats.guest.IsAdult } ");
                            }

                        }
                    }
                }
                AnsiConsole.Write(root);
                AnsiConsole.Markup("Press [red underline]ENTER[/] to continue:\n");
                Console.Read();
            }

            void ShowGuests(List<Group> groupList, List<Guest> guestList)
            {
                var table = new Table();
                table.Title("\n[red]All Guests[/]");
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
                AnsiConsole.Markup("\n[italic]* This table is ordered by group id[/]\n\n");
                Console.Read();

            }

            void ShowGroups(List<Group> groupList, List<Guest> guestList)
            {
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
                Console.Read();

            }


        }
    }
}
