using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class MultiCellBuffer
    {
        public OrderClass[] orders_buffer; //buffer cells: structure to hold order objects
        private const int N = 5; //number of ticket agencies
        private int n; //buffer capacity
        private static int count = 0;
        private static Semaphore write_pool, read_pool; //write and read pool to control write and read access


        int read_index = 0; // read buffer index
        int write_index = 0; // write buffer index

        //constructor
        public MultiCellBuffer(int buffer_capacity)
        {
            lock (this)
            {

                this.n = buffer_capacity; // to initialize the buffer capacity
                write_pool = new Semaphore(n, n);
                read_pool = new Semaphore(n, n);
                this.orders_buffer = new OrderClass[this.n]; //creating n buffer cells

                for (int i = 0; i < this.n; i++)
                {
                    this.orders_buffer[i] = null; //initializing buffer cells(empty buffer cells)
                }
            }
        }

        //To write data into one of the available cell
        public void setOneCell(OrderClass order)
        {
            Monitor.Enter(this);
            write_pool.WaitOne();

            lock (this)
            {
                while (count >= this.n)
                {
                    try
                    {
                        Monitor.Wait(this); // If all the cells are full, current thread waits

                    }
                    catch { }
                }

                this.orders_buffer[write_index] = order; //adding the current order to the available cell
                write_index = (write_index + 1) % 2;
                count++;

                write_pool.Release();
                Monitor.Pulse(this);
                Monitor.Exit(this);
            }
        }


        //To get order from the order buffer cell
        public OrderClass getOneCell()
        {
            Monitor.Enter(this);
            read_pool.WaitOne();
            OrderClass orderOutput = null;

            lock (this)
            {
                while (count <= 0)
                {
                    try
                    {
                        Monitor.Wait(this); //If no cells are full, the current thread waits
                    }
                    catch { }
                }

                orderOutput = orders_buffer[read_index]; //reading an order

                if (orderOutput != null)
                {
                    this.orders_buffer[read_index] = null;
                    read_index = (read_index + 1) % 2;
                    count--;
                    Console.WriteLine("Order {0} is fetched from the buffer cell", orderOutput.getSenderId());
                }


                read_pool.Release();
                Monitor.Pulse(this);
                Monitor.Exit(this);
            }

            return orderOutput;


        }
    }
}
