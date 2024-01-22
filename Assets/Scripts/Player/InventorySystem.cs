using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //FIND TUTORIAL FOR INVENTORY SYSTEM

    private Dictionary<int, int> inventory = new Dictionary<int, int>();

    public void AddItem(int itemID, int quantity)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID] += quantity;
        }
        else
        {
            inventory.Add(itemID, quantity);
        }
    }

    public void RemoveItem(int itemID, int quantity)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID] -= quantity;

            if (inventory[itemID] <= 0)
            {
                inventory.Remove(itemID);
            }
        }
        else
        {
            Debug.LogWarning("Item not found in inventory: " + itemID);
        }
    }

    public bool HasItem(int itemID)
    {
        return inventory.ContainsKey(itemID);
    }

    public int GetItemQuantity(int itemID)
    {
        return inventory.ContainsKey(itemID) ? inventory[itemID] : 0;
    }
}
