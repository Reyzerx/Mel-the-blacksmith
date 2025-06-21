using UnityEngine;

public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public bool stackable = true;
    public int maxStackSize = 99;
}
