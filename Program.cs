using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            master.Connect(ipEnd);

            string sendData = "";

            do
            {
                Console.Write("Send Message: ");
                sendData = Console.ReadLine();
                master.Send(System.Text.Encoding.UTF8.GetBytes(sendData));
                byte[] pbd = new byte[4];
                master.Receive(pbd);
                Console.WriteLine("Server Response: " + System.Text.Encoding.UTF8.GetString(pbd));
            } while (sendData.Length > 0);

            master.Close();
        }
    }
}
