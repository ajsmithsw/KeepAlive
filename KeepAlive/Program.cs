using System;
using System.Net.NetworkInformation;
using System.Text;

namespace KeepAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("You forgot to pass in the IP to ping!");
                return;
            }

            var url = args[0];

            new Start().Run(url);
        }
    }

    public class Start
    {
		public async void Run(string url)
		{

			//bool pingable = false;
			Ping pinger = new Ping();
			byte[] buffer = Encoding.ASCII.GetBytes(ip);

            while (true)
            {
                try
                {
                    PingReply reply = await pinger.SendPingAsync(url);

                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("");
                    }

                    //pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
            }
		}
    }
}
