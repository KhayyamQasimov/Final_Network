using System.Net.Sockets;
using Final_Client;

namespace Final_Client;

class CacheProxy : ILeaderService
{
    private DbLeaderService db = new();
    private BinaryReader br;
    private BinaryWriter bw;

    public CacheProxy(NetworkStream stream)
    {
        br = new BinaryReader(stream);
        bw = new BinaryWriter(stream);
    }

    public string? GetLeader(int id)
    {
        bw.Write($"GET|{id}");
        var answer = br.ReadString();

        if (answer != "NULL")
        {
            Console.WriteLine("Cache-den geldi");
            return answer;
        }

        Console.WriteLine("SQL-den geldi");
        var leader = db.GetLeader(id);

        if (leader != null)
        {
            bw.Write($"PUT|{id}|{leader}");
            br.ReadString();
        }

        return leader;
    }
}