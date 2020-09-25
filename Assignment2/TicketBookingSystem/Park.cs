using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class Park
    {
        public Random random = new Random();
        private const int MAX_P = 5;
        private static int p = 1;
        private static int index = 0;
        public static double currentPrice = 25, previousPrice = 0.0;

        public static event priceCutEvent priceCutEvent;
        
        public double getCurrentPrice() { return currentPrice; }

        public static void changePrice(int price)
        {
            if(index==Program.agencies.Length)
            {
                index = 0;
            }
            if(priceCutEvent!=null)
            {
                if(price<currentPrice)
                {
                    priceCutEvent(price, Program.agencies[index].Name);
                    index++;
                    p++;
                }

                if(price!=currentPrice)
                {
                    currentPrice = price;
                }
            }
        }

        public void parkFunc()
        {
            while(p<MAX_P)
            {
                Thread.Sleep(random.Next(1000, 5000));
                changePrice(PricingModel.getPrice());
            }

            Program.parkThreadRunning = false;
        }

        public void runOrderFunc()
        {
            OrderClass order = Program.multiCellBuffer.getOneCell();
            Thread threadObj = new Thread(() => OrderProcessing.processOrder(order, getCurrentPrice()));
            threadObj.Start();
        }


    }
}
