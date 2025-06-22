using UnityEngine;
using UnityEngine.UI;

public class PlayerMiniGameInterractionMinerai : MonoBehaviour
{
    public GameObject interactionIcon;
    public Button actionButton;
    public MiniGameController miniGameController;

    private WorldItem currentItem;

    public Inventory inventory;

    void Start()
    {
        interactionIcon.SetActive(false);
        actionButton.onClick.AddListener(LaunchMiniGame);
    }

    public void StartInterraction(WorldItem item)
    {
        currentItem = item;
        interactionIcon.SetActive(true);
    }

    public void EndInterraction()
    {
        currentItem = null;
        interactionIcon.SetActive(false);
    }

    public void LaunchMiniGame()
    {
        if (currentItem != null && inventory != null)
        {
            miniGameController.StartMiniGame(currentItem, inventory);
            interactionIcon.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Mini-jeu non démarré : item ou inventory manquant.");
        }
    }
}
