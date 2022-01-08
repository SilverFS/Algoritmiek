using System;
using System.Linq;

namespace Algoritmiek
{
    public class Program
    {
        static Event greatEvent = new Event();
        static void Main(string[] args)
        {

            var printGuests = greatEvent.CreateGuests();
            var printBoxes = greatEvent.CreateBoxes();
            Console.WriteLine("Total guests: " + printGuests.Count);
            foreach (var item in printGuests)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("_____________________");



            Console.WriteLine("Total box count: " + printBoxes.Count);
            Console.WriteLine("____________");

            foreach (var boxes in printBoxes)
            {
                Console.WriteLine("| Box " + boxes.box_id + ":");
                foreach (var rows in boxes.rowList)
                {
                    Console.WriteLine(" | ROW " + rows.row_id + ":");
                    foreach (var seats in rows.seatList)
                    {
                        Console.WriteLine("  | SEAT " + seats.seat_id + ",");
                    }
                    Console.WriteLine("_________");
                }
                Console.WriteLine("_____________________");
            }

            Console.ReadLine();
        }
    }
}
