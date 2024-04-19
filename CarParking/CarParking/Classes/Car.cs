using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Classes
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ParkingTime { get; set; }
        public int QueTime { get; set; }

    }
}
