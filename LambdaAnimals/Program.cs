
using System.Diagnostics;

Dog d1 = new Dog("King", 25);
Dog d2 = new Dog("Tiny", 95);
Dog d3 = new Dog("Rufus", 36);
Dog d4 = new Dog("Spot", 55);
Dog d5 = new Dog("Daisy", 8);
List<Dog> dogs = new List<Dog> { d1, d2, d3, d4, d5 };

// Print out all Dogs with a weight larger than 40 kg.

foreach(var dog in dogs)
{
    if (dog.Weight > 40)
    {
        Debug.WriteLine(dog+ " Bigger than 40 kg");
    }
}


foreach(var d in dogs)
{
    if(d.Weight < d3.Weight)
    {
        Debug.WriteLine(d + "Smaller than Rofus");
    }
}



// Print out all Dogs with a weight smaller than Rufus' weight.

foreach(var d in dogs)
{
    if (d.Name.Contains("i"))
    {
        Debug.WriteLine(d.Name + " Contains i");
    }
}

// Print out all Dogs with a name that contains an "i"


static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
{
    Console.WriteLine();
    foreach (var item in objects.FindAll(pred))
    {
        Console.WriteLine(item);
    }
}
