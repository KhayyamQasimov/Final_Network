using System.Net.Sockets;
using Final_Client;

namespace Final_Client;

class Program
{
    static void Main()
    {
        var client = new TcpClient("127.0.0.1", 27001);
        ILeaderService service = new CacheProxy(client.GetStream());

        while (true)
        {
            Console.Write("Leader Id: ");
            var id = int.Parse(Console.ReadLine()!);

            Console.WriteLine(service.GetLeader(id) ?? "Tapilmadi");
        }
    }
}