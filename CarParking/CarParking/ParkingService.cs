using CarParking.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking
{
    public class ParkingService
    {
        private SemaphoreSlim lockObject = new SemaphoreSlim(1, 1);
        public async Task QueCarAsync(int queTime)
        {
            await Task.Delay(queTime);  
        }


        public async Task<bool> RequestParkingAsync(ParkingLot parkingLot)
        {
            await lockObject.WaitAsync();
            try
            {
                var parkingSpotsLeft = parkingLot.TotalSpaces - parkingLot.ParkedCars.Count();
                return parkingSpotsLeft > 0;
            }
            finally
            {
                lockObject.Release();
            }
        }

        public async Task ParkCarAsync(Car car, ParkingLot parkingLot)
        {
            await lockObject.WaitAsync();
            try
            {
                parkingLot.ParkedCars.Add(car);
            }
            finally
            {
                lockObject.Release();
            }
        }

        public async Task CarIsCurrentlyParked(int parkTime)
        {
            await Task.Delay(parkTime);
        }


        public async Task LeaveParkingLot(ParkingLot parkingLot, Car car)
        {
            await lockObject.WaitAsync();
            try
            {
                parkingLot.ParkedCars.Remove(car);
            }
            finally
            {
                lockObject.Release();
            }
        }

            

    }
}
