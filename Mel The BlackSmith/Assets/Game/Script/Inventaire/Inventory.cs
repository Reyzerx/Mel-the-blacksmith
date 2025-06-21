using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size = 20;
    public List<InventorySlot> slots = new();

    void Awake()
    {
        for (int i = 0; i < size; i++)
            slots.Add(new InventorySlot(null, 0));
    }

    public bool AddItem(InventoryItem newItem, int quantity = 1)
    {
        // Tentative d'empilement
        foreach (var slot in slots)
        {
            if (slot.item == newItem && newItem.stackable && !slot.IsFull)
            {
                slot.quantity += quantity;
                return true;
            }
        }

        // Ajout dans un nouveau slot
        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = newItem;
                slot.quantity = quantity;
                return true;
            }
        }

        Debug.Log("Inventaire plein !");
        return false;
    }
}
