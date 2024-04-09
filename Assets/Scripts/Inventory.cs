using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        switch (item.itemType)
        {
            case "Potion":
                // Add a potion to the inventory'
                items.Add(item);
                Debug.Log("Potion Type");
                break;

            default:
                Debug.LogError("Invalid item type: " + item.itemType);
                break;
        }
    }

    public int CountStones()
    {
        return items.Count(i => i.itemType == "Stone");
    }

    public int CountPotions()
    {
        return items.Count(i => i.itemType == "Potion");
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    public int GetItemCount(Item item)
    {
        return items.Count(i => i == item);
    }
}
