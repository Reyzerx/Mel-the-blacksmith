using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public InventoryItem item;  // Le ScriptableObject à ajouter dans l'inventaire
    public int quantity = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on rentre en collision avec :" + collision.name);

        if (collision.CompareTag("Player"))
        {
            PlayerMiniGameInterractionMinerai interractionMinerai = collision.GetComponent<PlayerMiniGameInterractionMinerai>();
            if (interractionMinerai != null)
            {
                interractionMinerai.StartInterraction(this);
            }

            PlayerCore playerCore = collision.GetComponent<PlayerCore>();
            if (playerCore != null)
            {
                playerCore.OnPlayerNearMineable();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMiniGameInterractionMinerai interractionMinerai = other.GetComponent<PlayerMiniGameInterractionMinerai>();
            if (interractionMinerai != null)
            {
                interractionMinerai.EndInterraction();
            }

            PlayerCore playerCore = other.GetComponent<PlayerCore>();
            if (playerCore != null)
            {
                playerCore.OnPlayerLeavesMineable();
                playerCore = null;
            }
        }
    }
}
