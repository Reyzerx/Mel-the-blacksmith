using UnityEngine;

[CreateAssetMenu(fileName = "New ToolItem", menuName = "Inventory/Tool")]
public class ToolItem : InventoryItem
{
    public int durability;
    public enum ToolType { Pioche, Marteau }
    public ToolType toolType;

    public void Use()
    {
        durability--;
        // check for breakage, etc.
    }
}
