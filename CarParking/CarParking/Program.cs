using CarParking;
using CarParking.Classes;

Console.WriteLine("Welcome to parking lot");
Console.WriteLine("Creating cars");

var parkingLot = new ParkingLot { Name = "ParkingLot1", TotalSpaces = 1, ParkedCars= new List<Car>() };
var parkingService = new ParkingService();
var car1 = new Car { Model = "Model1", ParkingTime = 1000000, Color = "Red" , QueTime = 3000};
var car2 = new Car { Model = "Model2", ParkingTime = 35162, Color = "Blue" , QueTime = 7000};
var car3 = new Car { Model = "Model3", ParkingTime = 2742, Color = "Yellow", QueTime = 34523 };
var car4 = new Car { Model = "Model4", ParkingTime = 50000, Color = "Green", QueTime = 16135 };


var ActiveCars = new List<Car>();
ActiveCars.Add(car1);
ActiveCars.Add(car2);
ActiveCars.Add(car3);
ActiveCars.Add(car4);
Dictionary<Task, Car> tasksForParkedCards = new Dictionary<Task, Car>();
Dictionary<Task,Car> tasks = new Dictionary<Task,Car>();
foreach (var car in ActiveCars)
{
    var task = parkingService.QueCarAsync(car.QueTime);
    tasks.Add(task, car);
}
while (true)
{
    try
    {
        var completedTask = await Task.WhenAny(tasks.Keys.Concat(tasksForParkedCards.Keys));
        if (tasks.ContainsKey(completedTask))
        {
            var car = tasks[completedTask];
            tasks.Remove(completedTask);
            Console.WriteLine($"Car is requesting parking {car.Model}");
            var granted = await parkingService.RequestParkingAsync(parkingLot);
            if (granted)
            {
                Console.WriteLine($"Parking granted for {car.Model}. Parking now...");
                await parkingService.ParkCarAsync(car, parkingLot);
                var parkTask = parkingService.CarIsCurrentlyParked(car.ParkingTime);
                tasksForParkedCards.Add(parkTask, car);
                Console.WriteLine($"Car was parked successfully {car.Model}");
            }
            else
            {
                Console.WriteLine($"Parking denied for {car.Model}. Requeuing...");
                var newTask = parkingService.QueCarAsync(car.QueTime);
                tasks.Add(newTask, car);
            }
        }
        else if (tasksForParkedCards.ContainsKey(completedTask))
        {
            var car = tasksForParkedCards[completedTask];
            tasksForParkedCards.Remove(completedTask);
            Console.WriteLine($"Car is leaving lot {car.Model}");
            await parkingService.LeaveParkingLot(parkingLot, car);
            var queueTask = parkingService.QueCarAsync(car.QueTime);
            tasks.Add(queueTask, car);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
  



