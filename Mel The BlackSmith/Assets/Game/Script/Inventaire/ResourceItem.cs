using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceItem", menuName = "Inventory/Resource")]
public class ResourceItem : InventoryItem
{
    public enum ResourceType { Minerai, Lingot }
    public ResourceType resourceType;
}
