using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class OrderClass
    {
        private string senderId;
        private int cardNo;
        private string receiverId;
        private int amount;
        private double unitPrice;

        public OrderClass()
        {

        }
        public OrderClass(string senderId, int cardNo, int amount, double unitPrice)
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
