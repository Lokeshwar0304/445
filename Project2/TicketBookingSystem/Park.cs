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
        private const int MAX_P = 20; //maximum number of price cuts
        private static int p = 1; // price cut counter
        private static int index = 0;
        public static double current_price = 15;

        // price-cut event that can emit an event and call the event handlers in the TicketAgency if there is a price-cut according to the PricingModel
        public static event priceCutEvent priceCutEvent; 
        
        public double getcurrent_price() { return current_price; }

        public static void changePrice(int new_price)
        {
            if(index==Program.agencies.Length)
            {
                index = 0;
            }
            if(priceCutEvent!=null)
            {
                if(new_price<current_price) // to checks if new price is less than current price
                {
                    if (priceCutEvent!=null) priceCutEvent(new_price, Program.agencies[index].Name); //emits the promotional event
                    index++;
                    p++;
                    
                }

                current_price = new_price; //assigning the new price to current price
            }
        }

        //method that calls PricingModel to determine the ticket price
        public void parkFunc()
        {
            while(p<=MAX_P)
            {
                Thread.Sleep(RandomClass.getNext(1000, 2000)); // to generate a new price every 1-5 seconds
                changePrice(PricingModel.getPrice());
            }

            Program.parkThreadRunning = false;
        }

        //method to receive an OrderObject from the MultiCellBuffer
        public void runOrderFunc()
        {
            OrderClass order = Program.multiCellBuffer.getOneCell(); //to fetch an order from MultiCellBuffer
            Console.WriteLine("creating a new orderProcessing thread to process {0} order for {1} tickets for the price ${2}", order.getSenderId(), order.getAmount(), getcurrent_price());
            Thread threadObj = new Thread(() => OrderProcessing.processOrder(order, getcurrent_price())); //creating a new orderProcessing thread to process the order
            threadObj.Start(); // start the thread to process the request
        }


    }
}
