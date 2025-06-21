using UnityEngine;

public class InventoryToggleButton : MonoBehaviour
{
    public InventoryUIManager inventoryUI;

    public void OnButtonPressed()
    {
        inventoryUI.ToggleInventory();
    }
}
