using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Classes
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> ParkedCars { get; set; }
        public int TotalSpaces { get; set; }
    }
}
