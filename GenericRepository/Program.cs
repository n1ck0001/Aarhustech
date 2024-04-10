
using GenericRepository;
using System.Diagnostics;
epoG<Car> items = new epoG<Car>();
epoG<Employee> employees = new epoG<Employee>();
epoG<Computer> Pcs = new epoG<Computer>();

Car car1 = new Car("123", 100);
Car car2 = new Car("12", 1002);
Car car3 = new Car("153", 1030);
Car car4 = new Car("1553", 1040);
items.Insert(car1.LicensePlate, car1);
items.Insert(car2.LicensePlate, car2);
items.Insert(car3.LicensePlate, car3);
items.Insert(car4.LicensePlate, car4);
Car c1 = new Car("AB 12 345", 80000);
Car c2 = new Car("CD 34 456", 65000);
Car c3 = new Car("EF 56 567", 28000);
items.Insert(c1.LicensePlate, c1);
items.Insert(c2.LicensePlate, c2);
items.Insert(c3.LicensePlate, c3);


Employee e1 = new Employee("Allan", 1962);
Employee e2 = new Employee("Bente", 1975);
Employee e3 = new Employee("Carlo", 1973);
employees.Insert(e2.Name, e2);
employees.Insert(e3.Name, e3);


Computer com1 = new Computer("SerialNumberPc1", "netowkringNamePc1");
Computer com2 = new Computer("SerialNumberPc2", "netowkringNamePc2");
Computer com3 = new Computer("SerialNumberPc3", "netowkringNamePc3");
Pcs.Insert(com1.SerialNo, com1);
Pcs.Insert(com2.SerialNo, com2);
Pcs.Insert(com3.SerialNo, com3);

Debug.WriteLine("----");
employees.PrintAll();
items.PrintAll();
Pcs.PrintAll();

