using System;

namespace Exercise_1
{
    internal class Client
    {
        //Client Class with id of the client and his enterTime to the Queue
        public int id;
        public DateTime enterTime;

        public Client(int id)
        {
            this.id = id;
            this.enterTime = DateTime.Now;
        }
    }
}