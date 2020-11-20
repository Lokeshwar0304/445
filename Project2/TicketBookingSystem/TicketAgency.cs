using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class TicketAgency
    {
        
        public static event orderCreatedEvent orderCreated; //event for the ticket agency about the availability of a new order

        //function to start a new thread which runs until the park thread runs
        public void ticketAgencyFunc() 
        {
            while(Program.parkThreadRunning)
            {
                Thread.Sleep(RandomClass.getNext(2000, 4000));
                createOrderFunc(Thread.CurrentThread.Name);
            }
        }

        //function to create a new order
        private void createOrderFunc(string senderId)
        {
            int cardNo = RandomClass.getNext(5000, 7000); //to generate a random card number
            int amount = RandomClass.getNext(10, 200); //to generate a random number of tickets 

            OrderClass order = new OrderClass(senderId, cardNo, amount,PricingModel.getPrice()); // new order object 

            Console.WriteLine("{0}'s order with {1} tickets has been created at {2}", senderId, amount, DateTime.Now.ToString("hh:mm:ss"));

            Program.multiCellBuffer.setOneCell(order); // insert the new order into multicellbuffer

            orderCreated(); 

        }
        
        public void orderProcessed(string senderId, int amountToCharge, double price, int amount) //event handler
        {
            Console.WriteLine("{0}'s order with {1} tickets has been processed at {2}", senderId, amount, DateTime.Now.ToString("hh:mm:ss"));
        }

        //method called by the park when a price-cut event occurs
        public void ticketOnSale(int price, string senderId)
        {
            createOrderFunc(senderId);
        }
    }
}
