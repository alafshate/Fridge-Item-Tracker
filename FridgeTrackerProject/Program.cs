using System;
using Models.Fridge;
using Models.FridgeItem;

public class Program
{
    public static void Main(string[] args)
    {
        Fridge myFridge = new Fridge();

        // Add items to the fridge
        FreezerItem freezerItem1 = new FreezerItem("Chicken", DateOnly.FromDateTime(DateTime.Now.AddDays(-2))); // Already expired
        FreezerItem freezerItem2 = new FreezerItem("Fish", DateOnly.FromDateTime(DateTime.Now.AddDays(5))); // Not expired
        RefrigeratorItem fridgeItem1 = new RefrigeratorItem("Milk", DateOnly.FromDateTime(DateTime.Now.AddDays(2))); // Not expired
        RefrigeratorItem fridgeItem2 = new RefrigeratorItem("Cheese", DateOnly.FromDateTime(DateTime.Now.AddDays(-1))); // Already expired

        Console.WriteLine(myFridge.AddToFridge(freezerItem1)); // Output: True
        Console.WriteLine(myFridge.AddToFridge(freezerItem2)); // Output: True
        Console.WriteLine(myFridge.AddToFridge(fridgeItem1));  // Output: True
        Console.WriteLine(myFridge.AddToFridge(fridgeItem2));  // Output: True
        Console.WriteLine(myFridge.AddToFridge(fridgeItem1));  // Output: False (duplicate item)

        // Check expired items
        Console.WriteLine("Expired Items:");
        Console.WriteLine(myFridge.CheckExpiredItems());

        // Return all items
        Console.WriteLine("All Items in the Fridge:");
        Console.WriteLine(myFridge.ReturnAllItems());
    }
}
