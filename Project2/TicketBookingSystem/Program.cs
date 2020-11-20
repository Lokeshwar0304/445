using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    public delegate void priceCutEvent(int price, string senderId);
    public delegate void orderProcessedEvent(string senderId, int amountToCharge, double price, int amount);
    public delegate void orderCreatedEvent();

    class Program
    {
        public static Thread[] agencies;
        public static MultiCellBuffer multiCellBuffer;
        public static bool parkThreadRunning = true;

        static void Main(string[] args)
        {
            //Objects
            Park park = new Park(); // park object
            TicketAgency agency = new TicketAgency(); // ticket agency objec
            multiCellBuffer = new MultiCellBuffer(2); // initializing multi cell buffer with buffer size as 2


            //Park thread
            Thread parkFunc = new Thread(new ThreadStart(park.parkFunc)); // initialzing the park thread
            parkFunc.Start(); //starting the park thread


            //Events
            Park.priceCutEvent += new priceCutEvent(agency.ticketOnSale);  // execute ticketOnSale method when price-cut is made
            TicketAgency.orderCreated += new orderCreatedEvent(park.runOrderFunc); // execute runOrder method when the orderCreated event is emitted
            OrderProcessing.orderProcessed += new orderProcessedEvent(agency.orderProcessed); // processed order confirmation

            //Agency
            agencies = new Thread[5]; // creating a thread array of size 5(number of agencies=5)
            for (int i=0;i<5;i++)
            {
                
                agencies[i] = new Thread(new ThreadStart(agency.ticketAgencyFunc));
                agencies[i].Name = "Agency_"+(i + 1).ToString();
                agencies[i].Start(); // start the agency thread
            }


        }
    }
}
