using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class RandomClass
    {
        static Random random = new Random();


        public static int getNext(int upper_limit,int lower_limit)
        {
            return random.Next(upper_limit, lower_limit); // To generates a random value between lower_limit and upper_limit
        }
    }
}
