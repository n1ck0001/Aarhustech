using Microsoft.EntityFrameworkCore;
using Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class DbService : DbContext
    {
        public DbService() { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Lobby> Lobbys { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite("Data Source=C:\\Users\\NicolaiPrang\\Desktop\\DbForUno\\Uno.db");         
    }
}
