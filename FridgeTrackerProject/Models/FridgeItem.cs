using System;

namespace Models.FridgeItem
{
    public class FridgeItems
    {
        public string Name { get; private set; }
        public DateOnly ExpiryDate { get; protected set; }
        public DateOnly EntryDate { get; set; }
        public string Section { get; set; }

        public FridgeItems(string name, DateOnly expiryDate)
        {
            Name = name;
            ExpiryDate = expiryDate;
            EntryDate = DateOnly.FromDateTime(DateTime.Now); // Set entry date to today.
            Section = "Unknown";
        }

        public int DaysLeft()
        {
            // Return the number of days left until the expiry date.
            DateTime now = DateTime.Now;
            DateOnly today = DateOnly.FromDateTime(now);
            return (ExpiryDate.DayNumber - today.DayNumber);
        }
    }

    public class RefrigeratorItem : FridgeItems
    {
        public RefrigeratorItem(string name, DateOnly expiryDate)
            : base(name, expiryDate)
        {
            Section = "Refrigerator";
        }

        // Constructor to set expiry date to three days from today
        public RefrigeratorItem(string name) 
            : base(name, DateOnly.FromDateTime(DateTime.Now.AddDays(3)))
        {
            Section = "Refrigerator";
        }
    }

    public class FreezerItem : FridgeItems
    {
        public FreezerItem(string name, DateOnly expiryDate)
            : base(name, expiryDate)
        {
            Section = "Freezer";
        }

        public RefrigeratorItem MoveToRefrigerator()
        {
            // Return a new RefrigeratorItem with the expiry date set to three days from today.
            RefrigeratorItem newItem = new RefrigeratorItem(Name)
            {
                EntryDate = this.EntryDate // Ensure the entry date remains the same.
            };

            Console.WriteLine($"You have {newItem.DaysLeft()} days left to consume {Name}.");
            return newItem;
        }
    }
}
