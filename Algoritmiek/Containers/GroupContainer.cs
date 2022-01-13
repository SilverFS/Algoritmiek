using Algoritmiek.Models;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmiek.Containers
{
    public class GroupContainer
    {

        //needed: amount of groups, 
        public List<Group> FormGroups(List<Guest> guestList)
        {
            List<Group> groups = new();
            int allGroups = guestList.Select(x => x.group_id).Distinct().Count();

            for (int i = 0; i < allGroups; i++)
            {
                //Adds users with group id to group until the next id  
                groups.Add(new Group
                {
                    group_id = i,
                    children = guestList.Where(x => x.group_id == i && x.IsAdult == false).ToList(),
                    adults = guestList.Where(x => x.group_id == i && x.IsAdult == true).ToList(),
                });
            }

            groups = groups.OrderByDescending(x => x.children.Count + x.adults.Count).ToList();
            return groups;
        }
    }
}
