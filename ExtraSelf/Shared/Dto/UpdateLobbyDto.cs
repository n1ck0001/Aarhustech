using Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class UpdateLobbyDto
    {
        public Player Player { get; set; }
        public string HostId { get; set; }
    }
}
