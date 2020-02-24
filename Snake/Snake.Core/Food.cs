using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core
{
    public class Food
    {
        public Food(Location location)
        {
            Location = location;
        }

        public Location Location { get; set; }

        public void ChangeLocation(Location location)
        {
            Location = location;
        }
    }
}
