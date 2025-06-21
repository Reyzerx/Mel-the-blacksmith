using UnityEngine;

[CreateAssetMenu(fileName = "New ConsumableItem", menuName = "Inventory/Consumable")]
public class ConsumableItem : InventoryItem
{
    public int healthRestoreAmount;

    // public void Consume(Player player)
    // {
    //     player.Heal(healthRestoreAmount);
    // }
}
