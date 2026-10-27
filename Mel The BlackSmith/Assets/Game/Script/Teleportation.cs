using System.Collections;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private ScreenFade screenFade; // référence au script de fade
    [SerializeField] private float delayBeforeFadeIn = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            StartCoroutine(TeleportSequence(other.gameObject));
        }
    }

    private IEnumerator TeleportSequence(GameObject player)
    {
        var controller = player.GetComponent<PlayerMouvement>();
        if (controller != null)
        {
            Animator anim = player.GetComponent<Animator>();
            anim.SetFloat("speed", 0f);

            controller.enabled = false;
        }

        // Fade out
        yield return StartCoroutine(screenFade.FadeOut());

        // Téléportation
        player.transform.position = destination.position;

        // Petit délai avant fade in
        yield return new WaitForSeconds(delayBeforeFadeIn);

        // Fade in
        yield return StartCoroutine(screenFade.FadeIn());

        if (controller != null)
            controller.enabled = true;
    }
}
