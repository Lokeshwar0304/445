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
        public static event orderProcessedEvent orderProcessed; // this orderProcessed event is triggered whenever a new order is processed 

        private const int LocationCharge = 5;

        private const double TaxPercentage = 0.06;

        // to validate the credit card number
        private static bool validateCreditCard(int cardNumber)
        {
            return cardNumber >= 5000 && cardNumber <= 7000 ? true : false; //Returns true if the card number is between 5000 & 7000 inclusive. 
        }

        // method to instantiate a new thread to process the order
        public static void processOrder(OrderClass order, double unitPrice)
        {
            if(validateCreditCard(order.getCardNo())) //checking the validity of the credit card
            {
                double tax = unitPrice * order.getAmount() * TaxPercentage; //tax=unitprice * orderamount * 0.06
                double totalCharge = unitPrice * order.getAmount() + tax + LocationCharge; //totalcharge=unitprice * orderamount + tax + locationcharge
                orderProcessed(order.getSenderId(), Convert.ToInt32(totalCharge), unitPrice, order.getAmount());
            }
            else
            {
                Console.WriteLine("Invalid credit card number");
            }
            
        }
    }
}
