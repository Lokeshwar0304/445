using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class OrderClass
    {
        private string senderId; // the identity of the sender
        private int cardNo; //an integer that represents a credit card number
        private int amount; //an integer that represents the number of tickets to order
        private double unitPrice; //a double that represents the unit price of the ticket received from the park
        //private string receiverId;

        public OrderClass()
        {

        }
        public OrderClass(string senderId, int cardNo, int amount, double unitPrice) //constructor to initialize required attributes
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.amount = amount;
            this.unitPrice = unitPrice;
        }

        public string getSenderId() { return this.senderId; }
        public int getCardNo() { return this.cardNo; }
        public int getAmount() { return this.amount; }
        public double getUnitPrice() { return this.unitPrice; }
    }
}
