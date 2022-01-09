using System;
using Spectre.Console;

namespace Algoritmiek
{

    //Known issue: new menu entry gives new data.
    public class Program
    {
        static Event greatEvent = new Event();

        //Menu loop
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        //Menu definition
        private static bool MainMenu()
        {
            var printGuests = greatEvent.CreateGuests();
            Console.Clear();
            AnsiConsole.Markup("[bold green]Welcome to the event calculator![/] \n");
            AnsiConsole.Markup("The total guests amount to: " + "[teal slowblink]" + printGuests.Count + "[/]\n\n");
            AnsiConsole.Markup("Choose an option:\n");
            AnsiConsole.Markup("[yellow]1[/]) Displays a table of guests \n");
            AnsiConsole.Markup("[yellow]2[/]) Displays a tree view of boxes \n");
            AnsiConsole.Markup("\ntype '[red]exit[/]' to exit the program \n");
            AnsiConsole.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ListOfGuests();
                    Console.ReadLine();
                    return true;
                case "2":
                    ListOfBoxes();
                    Console.ReadLine();
                    return true;
                case "exit":
                    AnsiConsole.Markup("[bold orchid2]Goodbye![/]\n");
                    return false;
                default:
                    return true;
            }
        }

        //Show guests with content
        private static void ListOfGuests()
        {
            var table = new Table();
            table.Border(TableBorder.Simple);
            table.BorderColor(Color.Orange3);
            var printGuests = greatEvent.CreateGuests();
            AnsiConsole.Markup("\n[bold]Total guests: [/][teal slowblink]" + printGuests.Count + "[/]\n");
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
            AnsiConsole.Markup("\n[italic]* This table is ordered by group id[/]\n");
            AnsiConsole.Markup("\nPress Enter to continue:");
        }

        //Show boxes with content
        private static void ListOfBoxes()
        {
            //Add Tree
            var root = new Tree("[red bold]Event[/]").Style("red");
            var printBoxes = greatEvent.CreateBoxes();
            AnsiConsole.Markup("\n You have a total of: [teal slowblink]" + printBoxes.Count + "[/] boxes! \n");
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
                        singleRow.AddNode("[lime bold]Seat [/]" + seats.seat_id);
                    }
                }
            }
            AnsiConsole.Write(root);
            AnsiConsole.Markup("\nPress Enter to continue:");
        }
    }
}
