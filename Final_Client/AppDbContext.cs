using System.Collections.Generic;
using Final_Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Final_Client;

class AppDbContext : DbContext
{
    public DbSet<Leader> Leaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connStr = "Data Source=DESKTOP-3OSU8GB\\SQLEXPRESS;Initial Catalog=NSDAP;Integrated Security=True;Trust Server Certificate=True";

        optionsBuilder.UseSqlServer(connStr);

        base.OnConfiguring(optionsBuilder);
    }
}