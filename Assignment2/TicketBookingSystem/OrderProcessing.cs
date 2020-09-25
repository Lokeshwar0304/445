using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{ 

    class OrderProcessing
    {
        public static event orderProcessedEvent orderProcessed;

        private const int LocationCharge = 5;

        // To validate the credit card number. 
        private static bool validateCreditCard(int cardNumber)
        {
            return cardNumber >= 5000 && cardNumber <= 7000 ? true : false; //Returns true if the card number is between 5000 & 7000 inclusive. 
        }

        public static void processOrder(OrderClass order, double unitPrice)
        {
            if(!validateCreditCard(order.getCardNo()))
            {
                return;
            }
            else
            {
                double tax = unitPrice * order.getAmount() * 0.06;
                orderProcessed(order.getSenderId(), Convert.ToInt32(unitPrice * order.getAmount() + tax + LocationCharge), unitPrice, order.getAmount());
            }
        }
    }
}
