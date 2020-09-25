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
            Park park = new Park();
            TicketAgency agency = new TicketAgency();

            multiCellBuffer = new MultiCellBuffer(2);

            Thread parkFunc = new Thread(new ThreadStart(park.parkFunc));

            parkFunc.Start();

            Park.priceCutEvent += new priceCutEvent(agency.ticketOnSale);
            TicketAgency.orderCreated += new orderCreatedEvent(park.runOrderFunc);
            OrderProcessing.orderProcessed += new orderProcessedEvent(agency.orderProcessed);

            agencies = new Thread[5];

            for (int i=0;i<5;i++)
            {
                agencies[i] = new Thread(new ThreadStart(agency.ticketAgencyFunc));
                agencies[i].Name = (i + 1).ToString() + "_Agency";
                agencies[i].Start();
            }


        }
    }
}
