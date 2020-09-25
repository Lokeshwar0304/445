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
        public OrderClass[] bufferString;
        private const int N = 5;
        private int bufferCells;
        private int count;
        private static Semaphore write_pool, read_pool;

        public MultiCellBuffer(int bufferCells)
        {
            lock(this)
            {
                count = 0;

                this.bufferCells = bufferCells;
                write_pool = new Semaphore(bufferCells, bufferCells);
                read_pool = new Semaphore(bufferCells, bufferCells);

                bufferString = new OrderClass[bufferCells];

                for (int i = 0; i < bufferCells; i++)
                {
                    bufferString[i] = null;
                }
            }
        }

        public void setOneCell(OrderClass order)
        {
            write_pool.WaitOne();

            lock(this)
            {
                while(count==bufferCells)
                {
                    Monitor.Wait(this);
                }

                for(int i=0;i<N;i++)
                {
                    if(bufferString[i]==null)
                    {
                        bufferString[i] = order;
                        count++;
                        break;
                    }
                }
                write_pool.Release();
                Monitor.Pulse(this);
            }
        }

        public OrderClass getOneCell()
        {
            read_pool.WaitOne();
            OrderClass orderOutput = new OrderClass();

            lock(this)
            {
                while(count==0)
                {
                    Monitor.Wait(this);
                }

                for(int i=0;i<bufferCells;i++)
                {
                    if(bufferString[i]!=null)
                    {
                        orderOutput = bufferString[i];
                        bufferString[i] = null;
                        count--;
                        break;
                    }
                }
                read_pool.Release();
                Monitor.Pulse(this);
            }
            return orderOutput;
            

        }
    }
}
