using CarParking;
using CarParking.Classes;

Console.WriteLine("Welcome to parking lot");
Console.WriteLine("Creating cars");

var parkingLot = new ParkingLot { Name = "ParkingLot1", TotalSpaces = 32, ParkedCars= new List<Car>() };
var parkingService = new ParkingService();
var ActiveCars = new List<Car>();
async Task CreateCars()
{
    var car5 = new Car { Model = "Toyota Corolla", ParkingTime = 24567, Color = "Black", QueTime = 15234 };
    var car6 = new Car { Model = "Honda Civic", ParkingTime = 15893, Color = "White", QueTime = 13745 };
    var car7 = new Car { Model = "Ford Focus", ParkingTime = 30000, Color = "Silver", QueTime = 12400 };
    var car8 = new Car { Model = "Chevrolet Impala", ParkingTime = 7200, Color = "Grey", QueTime = 5000 };
    var car9 = new Car { Model = "Nissan Sentra", ParkingTime = 56000, Color = "Blue", QueTime = 17820 };
    var car10 = new Car { Model = "Hyundai Elantra", ParkingTime = 46000, Color = "Red", QueTime = 6000 };
    var car11 = new Car { Model = "Subaru Outback", ParkingTime = 15000, Color = "Green", QueTime = 20000 };
    var car12 = new Car { Model = "Mazda CX-5", ParkingTime = 25000, Color = "Maroon", QueTime = 19200 };
    var car13 = new Car { Model = "BMW 3 Series", ParkingTime = 34000, Color = "Navy", QueTime = 15600 };
    var car14 = new Car { Model = "Mercedes-Benz C-Class", ParkingTime = 12200, Color = "Ivory", QueTime = 9000 };
    var car15 = new Car { Model = "Audi A4", ParkingTime = 48000, Color = "Orange", QueTime = 8400 };
    var car16 = new Car { Model = "Lexus RX", ParkingTime = 30670, Color = "Teal", QueTime = 13450 };
    var car17 = new Car { Model = "Volkswagen Golf", ParkingTime = 45820, Color = "Purple", QueTime = 11800 };
    var car18 = new Car { Model = "Toyota Camry", ParkingTime = 52300, Color = "Brown", QueTime = 11160 };
    var car19 = new Car { Model = "Honda Accord", ParkingTime = 23000, Color = "Pink", QueTime = 14230 };
    var car20 = new Car { Model = "Ford Mustang", ParkingTime = 36700, Color = "Lime", QueTime = 17300 };
    var car21 = new Car { Model = "Chevrolet Corvette", ParkingTime = 18900, Color = "Cyan", QueTime = 13420 };
    var car22 = new Car { Model = "Nissan Altima", ParkingTime = 25400, Color = "Magenta", QueTime = 15678 };
    var car23 = new Car { Model = "Hyundai Sonata", ParkingTime = 31300, Color = "Turquoise", QueTime = 19650 };
    var car24 = new Car { Model = "Subaru Impreza", ParkingTime = 44000, Color = "Violet", QueTime = 16530 };
    var car25 = new Car { Model = "Mazda 3", ParkingTime = 21700, Color = "Gold", QueTime = 18940 };
    var car26 = new Car { Model = "BMW X5", ParkingTime = 49820, Color = "Copper", QueTime = 10020 };
    var car27 = new Car { Model = "Mercedes-Benz GLC", ParkingTime = 36000, Color = "Indigo", QueTime = 14700 };
    var car28 = new Car { Model = "Audi Q5", ParkingTime = 28000, Color = "Tan", QueTime = 17350 };
    var car29 = new Car { Model = "Lexus ES", ParkingTime = 45000, Color = "Charcoal", QueTime = 16000 };
    var car30 = new Car { Model = "Volkswagen Passat", ParkingTime = 22900, Color = "Olive", QueTime = 18400 };
    var car31 = new Car { Model = "Toyota Highlander", ParkingTime = 37200, Color = "Mint", QueTime = 14000 };
    var car32 = new Car { Model = "Honda CR-V", ParkingTime = 39800, Color = "Beige", QueTime = 12100 };
    var car33 = new Car { Model = "Ford Explorer", ParkingTime = 32000, Color = "Rust", QueTime = 17760 };
    var car34 = new Car { Model = "Chevrolet Malibu", ParkingTime = 21000, Color = "Sky Blue", QueTime = 20010 };
    var car35 = new Car { Model = "Nissan Rogue", ParkingTime = 47000, Color = "Cream", QueTime = 14500 };
    var car36 = new Car { Model = "Hyundai Tucson", ParkingTime = 50000, Color = "Fuchsia", QueTime = 13200 };
    var car37 = new Car { Model = "Subaru Forester", ParkingTime = 26200, Color = "Pearl", QueTime = 15730 };
    var car38 = new Car { Model = "Mazda 6", ParkingTime = 37500, Color = "Cherry", QueTime = 18300 };
    var car39 = new Car { Model = "BMW 5 Series", ParkingTime = 34000, Color = "Sapphire", QueTime = 15100 };
    var car40 = new Car { Model = "Mercedes-Benz E-Class", ParkingTime = 31000, Color = "Plum", QueTime = 16670 };
    var car41 = new Car { Model = "Audi A6", ParkingTime = 22000, Color = "Graphite", QueTime = 19000 };
    var car42 = new Car { Model = "Lexus NX", ParkingTime = 36000, Color = "Blush", QueTime = 13900 };
    var car43 = new Car { Model = "Volkswagen Jetta", ParkingTime = 25700, Color = "Amber", QueTime = 19800 };
    var car44 = new Car { Model = "Toyota Prius", ParkingTime = 41000, Color = "Emerald", QueTime = 13400 };
    var car45 = new Car { Model = "Honda Fit", ParkingTime = 32800, Color = "Silver Blue", QueTime = 17200 };
    var car46 = new Car { Model = "Ford Fiesta", ParkingTime = 19400, Color = "Sunset Orange", QueTime = 15820 };
    var car47 = new Car { Model = "Chevrolet Spark", ParkingTime = 28000, Color = "Lavender", QueTime = 14440 };
    var car48 = new Car { Model = "Nissan Leaf", ParkingTime = 39500, Color = "Sea Green", QueTime = 16320 };
    var car49 = new Car { Model = "Hyundai Kona", ParkingTime = 24200, Color = "Wine", QueTime = 15000 };
    var car50 = new Car { Model = "Subaru Legacy", ParkingTime = 36750, Color = "Midnight Blue", QueTime = 18960 };

    // add ask for perms before leaving lot
    // add fines / arking tickets :D


    ActiveCars.Add(car5);
    ActiveCars.Add(car6);
    ActiveCars.Add(car7);
    ActiveCars.Add(car8);
    ActiveCars.Add(car9);
    ActiveCars.Add(car10);
    ActiveCars.Add(car11);
    ActiveCars.Add(car12);
    ActiveCars.Add(car13);
    ActiveCars.Add(car14);
    ActiveCars.Add(car15);
    ActiveCars.Add(car16);
    ActiveCars.Add(car17);
    ActiveCars.Add(car18);
    ActiveCars.Add(car19);
    ActiveCars.Add(car20);
    ActiveCars.Add(car21);
    ActiveCars.Add(car22);
    ActiveCars.Add(car23);
    ActiveCars.Add(car24);
    ActiveCars.Add(car25);
    ActiveCars.Add(car26);
    ActiveCars.Add(car27);
    ActiveCars.Add(car28);
    ActiveCars.Add(car29);
    ActiveCars.Add(car30);
    ActiveCars.Add(car31);
    ActiveCars.Add(car32);
    ActiveCars.Add(car33);
    ActiveCars.Add(car34);
    ActiveCars.Add(car35);
    ActiveCars.Add(car36);
    ActiveCars.Add(car37);
    ActiveCars.Add(car38);
    ActiveCars.Add(car39);
    ActiveCars.Add(car40);
    ActiveCars.Add(car41);
    ActiveCars.Add(car42);
    ActiveCars.Add(car43);
    ActiveCars.Add(car44);
    ActiveCars.Add(car45);
    ActiveCars.Add(car46);
    ActiveCars.Add(car47);
    ActiveCars.Add(car48);
    ActiveCars.Add(car49);
    ActiveCars.Add(car50);


}
await CreateCars().ConfigureAwait(false);

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
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine($"Car is requesting parking {car.Model}");
            Console.ForegroundColor = ConsoleColor.White;
            var granted = await parkingService.RequestParkingAsync(parkingLot);
            if (granted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Parking granted for {car.Model}. Parking now...");
                Console.ForegroundColor = ConsoleColor.White;
                await parkingService.ParkCarAsync(car, parkingLot);
                var parkTask = parkingService.CarIsCurrentlyParked(car.ParkingTime);
                tasksForParkedCards.Add(parkTask, car);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Car was parked successfully {car.Model}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Parking denied for {car.Model}. Requeuing...");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var newTask = parkingService.QueCarAsync(car.QueTime);
                tasks.Add(newTask, car);
            }
        }
        else if (tasksForParkedCards.ContainsKey(completedTask))
        {
            var car = tasksForParkedCards[completedTask];
            tasksForParkedCards.Remove(completedTask);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Car is leaving lot {car.Model}");
            Console.ForegroundColor = ConsoleColor.White;
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
  

