using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Exercise_1
{
    class Supermarket
    {
        //The supermarket calss with ConcurrentQueue for the thread safe so all the actions will be atomic
        public ConcurrentQueue<Client> supermarketQueue;
        Random random;

        public Supermarket()
        {
            this.supermarketQueue = new ConcurrentQueue<Client>();
            random = new Random();
        }

        //enter every second new client to the queue
        public void QueueManager()
        {
            int clientNum = 1;
            //while(true) because evert second new client enter the queue
            while (true)
            {
                Thread.Sleep(1000);
                Client enteringClient = new Client(clientNum);
                supermarketQueue.Enqueue(enteringClient);
                Console.WriteLine("Client " + clientNum + " has entered the queue at " + enteringClient.enterTime);
                clientNum++;
            }
        }

        public void SupermarketWork()
        {
            Client currentClient;
            //the cashiers is working all the time
            while (true)
            {
                //if we have client in the queue we will dequeue him from the queue and only then the thread of the cashier will enter here
                if (supermarketQueue.TryDequeue(out currentClient))
                {
                    //print how many people in the queue right now
                    Console.WriteLine("supermarketQueue.Count -> " + supermarketQueue.Count);
                    //the cashier processing time is between 1 sec to 5 sec then we put the thread in sleep for that randomaly time
                    int cashierProcessingTime = random.Next(1000, 5000);
                    Thread.Sleep(cashierProcessingTime);
                    //calculate the total waiting time of the client
                    double totalWaitingTime = DateTime.Now.Subtract(currentClient.enterTime).TotalSeconds;
                    //print the client id the cashier and the total waiting time
                    Console.WriteLine("Client " + currentClient.id + " served by cashier " + Thread.CurrentThread.Name
                        + " has left the cashier with total waiting time: " + totalWaitingTime + " seconds");
                }
            }
        }
    }
}
