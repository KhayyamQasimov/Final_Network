using System.Net;
using System.Net.Sockets;

namespace Server;

class Program
{
    static void Main()
    {
        var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 27001);
        listener.Start();
        Console.WriteLine("Server isleyir...");

        var client = listener.AcceptTcpClient();
        var stream = client.GetStream();
        var br = new BinaryReader(stream);
        var bw = new BinaryWriter(stream);

        var cache = new Dictionary<string, string>();

        try
        {
            while (true)
            {
                var parts = br.ReadString().Split('|', 3);

                if (parts[0] == "PUT")
                {
                    cache[parts[1]] = parts[2];
                    bw.Write("OK");
                }
                else
                {
                    bw.Write(cache.ContainsKey(parts[1]) ? cache[parts[1]] : "NULL");
                }
            }
        }
        catch { }
    }
}