using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
	public static void Main()
	{
			// Create a generic list of Boat objects and then convert them to a list of strings
			// using a custom generic class "CollectionHelper<T>".
  	    	List<Boat> genericBoatCollection = new List<Boat>();
  	    	Boat Mastercraft = new Boat{Horsepower=500, NumberOfSeats=4};
	    	Boat Dreamliner = new Boat{Horsepower=450, NumberOfSeats=2};
		    genericBoatCollection.Add(Mastercraft);
		    genericBoatCollection.Add(Dreamliner);
		
			// Use custom generic classs CollectionHelper<T> to convert the list of boats to a list of strings
            List<string> values = CollectionHelper<Boat>.ConvertToString(genericBoatCollection);
            foreach(string v in values)
            {
                Console.WriteLine($"Next value in genericBoatCollection is '{v}'");
            }
		
			// Drive the boats
			CollectionHelper<Boat>.DriveAll(genericBoatCollection);
		

            List<Car> genericCarCollection = new List<Car>();
            Car ford = new Car { Manufacturer = "Ford", Model = "Focus" };
            Car gmc = new Car { Manufacturer = "GMC", Model = "Journey" };
            Car honda = new Car { Manufacturer = "Honda", Model = "Civic" };

            genericCarCollection.Add(ford);
            genericCarCollection.Add(gmc);
            genericCarCollection.Add(honda);
		
			// Use custom generic classs CollectionHelper<T> to convert the list of cars to a list of strings		
            values = CollectionHelper<Car>.ConvertToString(genericCarCollection);
            foreach (string v in values)
            {
                Console.WriteLine($"Next value in genericCarCollection is '{v}'");
            }
		
			// Drive the cars
			CollectionHelper<Car>.DriveAll(genericCarCollection);
		
	}
}

// Specifies the interface that all objects using the CollectionHelper class must have
public interface IDriveable
{
	void Drive();
	int MilesTillEmpty{get; set;}
}

// Defines a dummy helper class that will convert all (IDriveable) objects in a collection to string.
// Because we know that all objects of type <T> implement IDriveable, we can call the "Drive"
// method on each.
public static class CollectionHelper<T> where T: class, IDriveable
{
	// Convert every object in the list to a string
    public static List<string> ConvertToString(List<T> ObjectToConvert)
    {
        List<string> Converted = new List<string>();
        foreach(T EnumerableItem in ObjectToConvert)
        {
			// Now convert it to its string value
            Converted.Add(EnumerableItem.ToString());
        }

        return (Converted);
    }
	
	// Drive every object in the list
    public static void DriveAll(List<T> ObjectToDrive)
    {
        foreach(T EnumerableItem in ObjectToDrive)
        {
			// Drive the vehicle
			EnumerableItem.Drive();
        }
    }	
}	

public class Car: IDriveable
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
	public int MilesTillEmpty{get; set;}

    public Guid UniqueId { get; }

    public Car()
    {
        UniqueId = new Guid();
		Random rnd = new Random();
		MilesTillEmpty = rnd.Next(1, 13); 		
    }
	
	public override string ToString()
	{
		return($"Manufacturer:{Manufacturer}\tModel:{Model}");
	}
	
	public void Drive()
	{
		for(int i =0; i < MilesTillEmpty; ++i)
		{
			Thread.Sleep(100);	
		}
		Console.WriteLine($"{this} car ran out of gas!");
	}
}

public class Boat: IDriveable
{
	public int Horsepower { get; set; }
	public int NumberOfSeats {get; set; }
	public int MilesTillEmpty{get; set;}

	public Guid UniqueId { get; }

	public Boat()
	{
		UniqueId = new Guid();
		Random rnd = new Random();
		MilesTillEmpty = rnd.Next(1, 10); 		
	}
	
	public override string ToString()
	{
		return($"Horsepower:{Horsepower}\tNumberOfSeats:{NumberOfSeats}");
	}	
	
	public void Drive()
	{
		for(int i =0; i < MilesTillEmpty; ++i)
		{
			Thread.Sleep(100);	
		}
		Console.WriteLine($"{this} boat ran out of gas!");
	}	
}
								  
								  
