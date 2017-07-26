using System;
using System.Net.NetworkInformation;

namespace KeepAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter address to ping: ");

            var url = Console.ReadLine();

            new Start().Run(url);
        }
    }

    public class Start
    {
		public async void Run(string url)
		{
			Ping pinger = new Ping();

            while (true)
            {
                try
                {
                    PingReply reply = await pinger.SendPingAsync(url);

                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Received from: {0}\n\ttime: {1}\n\tstatus: {2}", 
                                          reply.Address, reply.RoundtripTime, reply.Status.ToString());
                        System.Threading.Thread.Sleep(10000);
                    }
                    else
                    {
                        Console.WriteLine("Problem receiving response: {0}", reply.Status.ToString());
                        return;
                    }
                }
                catch (PingException e)
                {
                    Console.WriteLine("Exception: {0}\n{1}", e.Message, e.StackTrace);
                }
            }
		}
    }
}
