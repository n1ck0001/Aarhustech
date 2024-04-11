    
#region Create drinks
List<Drink> drinks = new List<Drink>();
drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
#endregion


foreach (var drink in drinks)
{
    Console.WriteLine(drink.Name);
}


var drinksWithoutAlcohol = drinks.Where(d => d.AlcoholicPartAmount == 0).ToList();
Console.WriteLine("\n");
Console.WriteLine("Drinks without alcohol");
foreach (var item in drinksWithoutAlcohol)
{
    Console.WriteLine(item.Name);
}


var drinksWithAlcohol = drinks.Where(d=>d.AlcoholicPartAmount > 0).ToList();
Console.WriteLine("\n");
Console.WriteLine("Drinks with alcohol");
foreach (var item in drinksWithAlcohol)
{
    Console.WriteLine($"{item.Name}, {item.AlcoholicPart}, {item.AlcoholicPartAmount}");
}

var sortedListOfDrinks = drinks.OrderBy(d=>d.Name).ToList();
Console.WriteLine("\n");
Console.WriteLine("Drinks sorted order");
foreach (var item in sortedListOfDrinks)
{
    Console.WriteLine($"{item.Name}");
}


var totalAlcohol = 0;
 foreach(var item in drinksWithAlcohol)
{
    totalAlcohol += item.AlcoholicPartAmount;
}
Console.WriteLine("\n");
Console.WriteLine("Total alcohol in all drinks");
 Console.WriteLine(totalAlcohol);


int totalDrinks = 0;    
double Alcohol = 0;
foreach(var item in drinksWithAlcohol)
{
    totalDrinks++;
    Alcohol += item.AlcoholicPartAmount;
}
Alcohol = Alcohol / totalDrinks;

Console.WriteLine("\n");
Console.WriteLine("avg alcohol");
Console.WriteLine(Alcohol);


var drinkListWithAlcoholOrderByAPartName = drinksWithAlcohol.OrderBy(d=>d.AlcoholicPart).ToList();
Console.WriteLine("\n");
Console.WriteLine("order by name of part");
foreach (var item in drinkListWithAlcoholOrderByAPartName)
{
    Console.WriteLine($"{item.Name}, {item.AlcoholicPart}, {item.AlcoholicPartAmount}");
}