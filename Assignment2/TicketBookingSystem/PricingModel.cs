using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class PricingModel
    {
        static Random random = new Random();
        
        public  PricingModel()
        {
            
        }

        public static int getPrice()
        {
            return random.Next(80, 300); // To generates a random price between 80 USD and 300 USD
        }
    }
}
