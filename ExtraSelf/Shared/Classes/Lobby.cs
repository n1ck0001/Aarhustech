using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Classes
{
    public class Lobby
    {

        public int Id { get; set; }
        public string HostId { get; set; }
        public List<Player> Players { get; set; }
        public bool HasStarted { get; set; }


    }
}
