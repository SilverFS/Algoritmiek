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


            Console.WriteLine("Boxes: " + printBoxes.Count);
            foreach (var item in printBoxes)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
