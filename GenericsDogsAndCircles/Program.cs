
#region Dog objects
using System.Diagnostics;

Dog dog1 = new Dog("King", 70, 55);
Dog dog2 = new Dog("Spot", 30, 10);
Dog dog3 = new Dog("Rufus", 80, 40);
#endregion

#region Circle objects
Circle c1 = new Circle(10, 2, 3);
Circle c2 = new Circle(15, 6, 0);
Circle c3 = new Circle(8, 12, 7);
#endregion

#region ObjectComparer test
ObjectComparer comparer = new ObjectComparer();
Debug.WriteLine(comparer.LargestDog(dog1, dog2, dog3));
Debug.WriteLine(comparer.LargestCircle(c1, c2, c3));
#endregion
