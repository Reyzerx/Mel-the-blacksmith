using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemSlotPrefab; // le prefab ItemSlot
    public Transform slotParent; // le Content
    public Inventory playerInventory; // référence à l'inventaire

    private List<GameObject> activeSlots = new List<GameObject>();

    void Start()
    {
        inventoryPanel.SetActive(false);
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        // Supprimer les anciens slots
        foreach (GameObject slot in activeSlots)
        {
            Destroy(slot);
        }
        activeSlots.Clear();

        // Ajouter les nouveaux slots
        foreach (InventorySlot slot in playerInventory.slots)
        {
            GameObject slotGO = Instantiate(itemSlotPrefab, slotParent);

            //TextMeshProUGUI itemNameText = slotGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Image itemSprite = slotGO.transform.GetChild(0).GetComponent<Image>();
            TextMeshProUGUI itemQuantityText = slotGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            if (slot.item != null)
            {
                itemSprite.sprite = slot.item.icon;
                itemQuantityText.text = $"x{slot.quantity}";
            }
            else
            {
                itemQuantityText.text = "[vide]";
            }

            activeSlots.Add(slotGO);
        }
    }

    // Méthode pour afficher/masquer l'inventaire
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf)
            RefreshInventoryUI();
    }
}
