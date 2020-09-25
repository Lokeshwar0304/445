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
        public static Random random = new Random();
        public static event orderCreatedEvent orderCreated;
        public void ticketAgencyFunc()
        {
            while(Program.parkThreadRunning)
            {
                Thread.Sleep(random.Next(2000, 5000));
                createOrderFunc(Thread.CurrentThread.Name);
            }
        }

        private void createOrderFunc(string senderId)
        {
            int cardNo = random.Next(5000, 7000);
            int amount = random.Next(10, 200);

            OrderClass order = new OrderClass(senderId, cardNo, amount,PricingModel.getPrice()); //Need to modify for unit price

            Console.WriteLine("{0}'s order has been created at {1}", senderId, DateTime.Now.ToString("hh:mm:ss"));

            Program.multiCellBuffer.setOneCell(order);

            orderCreated();

        }
        
        public void orderProcessed(string senderId, int amountToCharge, double price, int amount)
        {
            Console.WriteLine("{0}'s order has been processed at {1}", senderId, DateTime.Now.ToString("hh:mm:ss"));
        }

        public void ticketOnSale(int price, string senderId)
        {
            Console.WriteLine("{0} price sale by sender {1}", price, senderId);
            createOrderFunc(senderId);
        }
    }
}
