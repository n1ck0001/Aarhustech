using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Classes
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

    }
}