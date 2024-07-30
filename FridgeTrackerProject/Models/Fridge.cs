using System;
using System.Collections.Generic;
using System.Text;
using Models.FridgeItem;

namespace Models.Fridge {
    public class Fridge {
        List<RefrigeratorItem> RefrigeratorSection = new List<RefrigeratorItem>();
        List<FreezerItem> FreezerSection = new List<FreezerItem>();

        // Returns True if the item wasn't already in the fridge and returns False if tried to add the same item twice.
        public bool AddToFridge(FridgeItems fi) {
            if (fi.Section == "Freezer") {
                // Check if the item is already in the freezer
                if (FreezerSection.Exists(item => item.Name == fi.Name && item.ExpiryDate == fi.ExpiryDate)) {
                    return false;
                } else {
                    // Add item to the freezer and sort by expiry date
                    FreezerSection.Add((FreezerItem)fi);
                    FreezerSection.Sort((x, y) => x.ExpiryDate.CompareTo(y.ExpiryDate));
                    return true;
                }
            } else if (fi.Section == "Refrigerator") {
                // Check if the item is already in the refrigerator
                if (RefrigeratorSection.Exists(item => item.Name == fi.Name && item.ExpiryDate == fi.ExpiryDate)) {
                    return false;
                } else {
                    // Add item to the refrigerator and sort by expiry date
                    RefrigeratorSection.Add((RefrigeratorItem)fi);
                    RefrigeratorSection.Sort((x, y) => x.ExpiryDate.CompareTo(y.ExpiryDate));
                    return true;
                }
            }

            return false;
        }

        public string CheckExpiredItems() {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            List<string> expiredItems = new List<string>();

            foreach (var item in RefrigeratorSection) {
                if (item.ExpiryDate < today) {
                    expiredItems.Add($"Refrigerator: {item.Name} expired on {item.ExpiryDate}");
                }
            }

            foreach (var item in FreezerSection) {
                if (item.ExpiryDate < today) {
                    expiredItems.Add($"Freezer: {item.Name} expired on {item.ExpiryDate}");
                }
            }

            return expiredItems.Count > 0 ? string.Join("\n", expiredItems) : "No expired items.";
        }

        public string ReturnAllItems() {
            StringBuilder allItems = new StringBuilder();

            allItems.AppendLine("Refrigerator Items:");
            foreach (var item in RefrigeratorSection) {
                allItems.AppendLine($"{item.Name}, Expiry Date: {item.ExpiryDate}, Entry Date: {item.EntryDate}");
            }

            allItems.AppendLine("Freezer Items:");
            foreach (var item in FreezerSection) {
                allItems.AppendLine($"{item.Name}, Expiry Date: {item.ExpiryDate}, Entry Date: {item.EntryDate}");
            }

            return allItems.ToString();
        }
    }
}
