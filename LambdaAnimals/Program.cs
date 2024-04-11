
using System.Diagnostics;

Dog d1 = new Dog("King", 25);
Dog d2 = new Dog("Tiny", 95);
Dog d3 = new Dog("Rufus", 36);
Dog d4 = new Dog("Spot", 55);
Dog d5 = new Dog("Daisy", 8);
List<Dog> dogs = new List<Dog> { d1, d2, d3, d4, d5 };

// Print out all Dogs with a weight larger than 40 kg.



//// Print out all Dogs with a weight smaller than Rufus' weight.


// Print out all Dogs with a name that contains an "i"

Debug.WriteLine("Dogs with a weight larger than 40 kg:");
ConditionalPrint(dogs, item => item.Weight > 40);


Debug.WriteLine("\nDogs with a weight smaller than Rufus' weight:");
ConditionalPrint(dogs, item => item.Weight < d3.Weight);

Debug.WriteLine("\nDogs with a name that contains an 'i':");
ConditionalPrint(dogs, item => item.Name.Contains("i"));

 
static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
{
    Console.WriteLine();
    foreach (var item in objects.FindAll(pred))
    {
        Debug.WriteLine(item);
    }
}


ConditionalPrint2(dogs, item => item.Weight < d3.Weight, item => item.Name == item.Name);

static void ConditionalPrint2<T>(List<T> objects, Predicate<T>pred1, Predicate<T>pred2)
{
    Console.WriteLine();
    foreach(var item in objects.FindAll(item => pred1(item) && pred2(item)))
    {
        Debug.WriteLine(item);
    }
}

