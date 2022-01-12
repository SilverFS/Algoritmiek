using System;
using System.Collections.Generic;
using Algoritmiek.Models;
using Algoritmiek.Containers;
using System.Linq;
using Spectre.Console;

namespace Algoritmiek
{

    //Known issue: new menu entry gives new data.
    class Program
    {
        static Event greatEvent = new Event();
        static GuestContainer guestContainer = new GuestContainer();
        static BoxContainer boxContainer = new BoxContainer();




        //Menu loop
        static void MainOld(string[] args)
        {
            boxContainer.CreateBoxes();
            guestContainer.CreateGuestList();
            //guestContainer.CreateFailedGuestList();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            while (showMenu == false)
            {
                boxContainer.CreateBoxes();
                guestContainer.CreateGuestList();
                // guestContainer.CreateFailedGuestList();
            }
        }


        //Menu definition
        private static bool MainMenu()
        {
            var printGuests = guestContainer.CreateGuestList();
            //var printGuests = guestContainer.CreateGuestList();
            Console.Clear();
            AnsiConsole.Markup("[bold green]Welcome to the event calculator![/] \n");
            AnsiConsole.Markup("The total guests amount to: [teal slowblink]", printGuests.Count, "[/]\n\n");
            AnsiConsole.Markup("Choose an option:\n");
            AnsiConsole.Markup("[yellow]1[/]) Generate event boxes\n");
            AnsiConsole.Markup("[yellow]2[/]) Displays a dummy table of random guests \n");
            AnsiConsole.Markup("[yellow]3[/]) Displays a dummy table of failed guests\n");
            AnsiConsole.Markup("[yellow]4[/]) Display every option at once\n");
            AnsiConsole.Markup("\nType '[red]exit[/]' to exit the program \n");
            AnsiConsole.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ListOfBoxes();
                    Console.ReadLine();
                    return true;
                case "2":
                    ListOfGuests();
                    Console.ReadLine();
                    return true;
                case "3":
                    //ListOfFailedGuests();
                    Console.ReadLine();
                    return true;
                case "4":
                    MainMenu();
                    Console.ReadLine();
                    return true;
                case "exit":
                    AnsiConsole.Markup("[bold orchid2]Goodbye![/]\n");
                    return false;
                default:
                    return true;
            }
        }




        //Show failed guests with content
        //private static void ListOfFailedGuests()
        //{
        //    var tableg = new Table();
        //    tableg.Border(TableBorder.Simple);
        //    tableg.BorderColor(Color.Orange3);
        //    var printFailedGuests = guestContainer.CreateFailedGuestList();
        //    var printGuests = guestContainer.CreateGuestList();

        //    AnsiConsole.Markup("\nThe total guests amount to: " + "[teal slowblink]" + printGuests.Count + "[/]\n");
        //    AnsiConsole.Markup("[bold]**The Total [green]passed[/] guests: [/][teal slowblink]" + printFailedGuests.Count + "[/]\n");
        //    //Add columns
        //    tableg.AddColumn("Guest");
        //    tableg.AddColumn("On Time");
        //    tableg.AddColumn("Is Adult");
        //    tableg.AddColumn("Group Number");
        //    foreach (var item in printFailedGuests)
        //    {
        //        //Add rows
        //        tableg.AddRow("" + item.guest_id + "", "" + item.OnTime + "", "" + item.IsAdult + "", "" + item.group_id + "");
        //    }
        //    AnsiConsole.Write(tableg);
        //    AnsiConsole.Markup("\n[italic]* This table is ordered by group id\n** This userlist is seperate data for boxes.\n   This means this table is completely irrelevant.[/]");
        //    AnsiConsole.Markup("\nPress Enter to continue:");
        //}




        //Show guests with content
        public static void ListOfGuests()
        {
            var table = new Table();
            table.Border(TableBorder.Simple);
            table.BorderColor(Color.Orange3);
            var printGuests = guestContainer.CreateGuestList();
            //var printFailedGuests = guestContainer.CreateFailedGuestList();
            //int passedGuests = Convert.ToInt32(printGuests.Count - printFailedGuests.Count);

            AnsiConsole.Markup("\nThe total guests amount to: " + "[teal slowblink]" + printGuests.Count + "[/]\n");
            //AnsiConsole.Markup("[bold]**The Total [green]passed[/] guests: [/][teal slowblink]" + passedGuests + "[/]\n");
            //Add columns
            table.AddColumn("Guest");
            table.AddColumn("On Time");
            table.AddColumn("Is Adult");
            table.AddColumn("Group Number");
            foreach (var item in printGuests)
            {
                //Add rows
                table.AddRow("" + item.guest_id + "", "" + item.OnTime + "", "" + item.IsAdult + "", "" + item.group_id + "");
            }
            AnsiConsole.Write(table);
            AnsiConsole.Markup("\n[italic]* This table is ordered by group id\n** This userlist is seperate data for boxes.\n   This means this table is completely irrelevant.[/]");
            AnsiConsole.Markup("\nPress Enter to continue:");
        }


        //Show boxes with content
        private static void ListOfBoxes()
        {
            //Add necessary components
            var printBoxes = boxContainer.CreateBoxes();
            var printGuests = guestContainer.CreateGuestList();

            //var boxesAndGuests = printBoxes.Zip(printGuestList, (b, g) => new { Boxes = b, Guests = g });
            //Add Tree root
            var root = new Tree("[red bold]Event[/]").Style("red");

            AnsiConsole.Markup("\n You have a total of: [teal slowblink]" + printBoxes.Count + "[/] boxes! \n");
            AnsiConsole.Markup("\n You have a total of: [teal slowblink]" + printGuests.Count + "[/] guests! \n");
            AnsiConsole.Markup("_____________________\n\n");
            //Add nodes in loops
            foreach (var boxes in printBoxes)
            {
                var singleBox = root.AddNode("[orangered1 bold]Box [/]" + boxes.box_id);
                foreach (var rows in boxes.rowList)
                {
                    var singleRow = singleBox.AddNode("[blue bold]Row [/]" + rows.row_id);
                    foreach (var seats in rows.seatList)
                    {
                        singleRow.AddNode("[lime bold]Seat [/]" + seats.seat_id + " -> guest: " + printGuests.Count);
                    }
                }
            }
            AnsiConsole.Write(root);
            AnsiConsole.Markup("\nPress Enter to continue:");
        }
    }
}
