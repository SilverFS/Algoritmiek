using Algoritmiek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek.Containers
{
    public class GroupContainer
    {

        //needed: amount of groups, 
        public List<Group> FormGroups(List<Guest> guestList)
        {
            List<Group> groups = new List<Group>();
            int count = 0;
            for (int i = 0; i < guestList.Count; i++)
            {
                //Adds users with group id to group until the next id
                if (guestList[i].group_id == count)
                {
                    groups.Add(new Group
                    {
                        group_id = count,
                        children = guestList.Where(x => x.group_id == count && x.IsAdult == false).ToList(),
                        guestsInGroup = guestList.Where(x => x.group_id == count && x.IsAdult == true).ToList(),
                    });
                    count++;
                }

            }

            groups = groups.OrderBy(x => x.group_id).ToList();
            return groups;
        }
    }
}
