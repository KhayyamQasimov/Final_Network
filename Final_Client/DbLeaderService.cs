namespace Final_Client;

class DbLeaderService : ILeaderService
{
    public string? GetLeader(int id)
    {
        using var db = new AppDbContext();
        var leader = db.Leaders.FirstOrDefault(l => l.Id == id);

        if (leader == null) return null;

        return $"{leader.FirstName} {leader.LastName}, Age: {leader.Age}, Rank: {leader.Rank}";
    }
}
