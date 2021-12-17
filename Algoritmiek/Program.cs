using System;

namespace Algoritmiek
{
    public class Program
    {
        static Event greatEvent = new Event();
        static void Main(string[] args)
        {

            var printGuests = greatEvent.CreateGuests();
            Console.WriteLine("Total guests: " + printGuests.Count);
            foreach (var item in printGuests)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
