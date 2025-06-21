using UnityEngine;
using UnityEngine.UI;

public class PlayerCore : MonoBehaviour
{

    public enum PlayerState
    {
        Idle,
        NearMineable,
        InMiniGame,
    }
    public PlayerState currentState;


    public Inventory inventory;
    // Référence au bouton UI (assignée dans l’inspecteur)
    public Button actionButton;
    private PlayerMouvement mouvementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Assure-toi que ce script gère bien le clic sur le bouton UI
        actionButton.onClick.AddListener(OnActionButtonPressed);

        mouvementScript = this.GetComponent<PlayerMouvement>();
    }

    // Cette fonction est appelée à chaque clic du bouton UI
    public void OnActionButtonPressed()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                Debug.Log("Aucune action possible");
                mouvementScript.SetMovementBlocked(false);
                break;
            case PlayerState.NearMineable:
                Debug.Log("Démarrage du mini-jeu");
                mouvementScript.SetMovementBlocked(true);
                // Exemple : lancer mini-jeu ici
                currentState = PlayerState.InMiniGame;
                break;
            case PlayerState.InMiniGame:
                Debug.Log("Validation du mini-jeu");
                mouvementScript.SetMovementBlocked(false);
                // Exemple : valider mini-jeu ici
                currentState = PlayerState.Idle;
                break;
        }
    }

    // Met à jour l’état interactif du bouton selon le contexte
    public void UpdateButtonInteractable()
    {
        actionButton.interactable = (currentState == PlayerState.NearMineable || currentState == PlayerState.InMiniGame);
    }

    // Exemple : appeler depuis ton trigger quand le joueur s’approche d’un minerai
    public void OnPlayerNearMineable()
    {
        currentState = PlayerState.NearMineable;
        UpdateButtonInteractable();
    }

    public void OnPlayerLeavesMineable()
    {
        currentState = PlayerState.Idle;
        UpdateButtonInteractable();
    }
}
