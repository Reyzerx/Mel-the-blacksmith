using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform greenZone;
    public Button actionButton;

    public float speed = 3f;
    public float successRange = 0.2f;

    private WorldItem targetItem;
    private Inventory inventory;

    private bool goingRight = true;
    private float leftBound = -1.3f;
    private float rightBound = 1.3f;

    void Start()
    {
        gameObject.SetActive(false);
        actionButton.onClick.AddListener(CheckSuccess);
    }

    public void StartMiniGame(WorldItem item, Inventory inv)
    {
        Debug.Log("Mini-jeu démarré avec : " + item?.name);

        targetItem = item;
        inventory = inv;

        PositionAboveItem(item.transform.position);
        ResetBar();

        gameObject.SetActive(true);
        StartCoroutine(MoveBar());
    }

    void PositionAboveItem(Vector3 itemWorldPos)
    {
        Vector3 offset = new Vector3(0, 1.5f, 0); // Position verticale au-dessus du minerai
        transform.position = itemWorldPos + offset;
    }

    void ResetBar()
    {
        goingRight = true;
        bar.anchoredPosition = new Vector2(leftBound, 0);
        float greenX = Random.Range(leftBound + 0.3f, rightBound - 0.3f);
        greenZone.anchoredPosition = new Vector2(greenX, 0);
    }

    IEnumerator MoveBar()
    {
        while (true)
        {
            float dir = goingRight ? 1 : -1;
            bar.anchoredPosition += new Vector2(dir * speed * Time.deltaTime, 0);

            if (bar.anchoredPosition.x >= rightBound)
                goingRight = false;
            else if (bar.anchoredPosition.x <= leftBound)
                goingRight = true;

            yield return null;
        }
    }

    void CheckSuccess()
    {
        if (targetItem == null || inventory == null)
        {
            //Debug.LogWarning("MiniGameController: targetItem ou inventory est null !");
            return;
        }

        float dist = Mathf.Abs(bar.anchoredPosition.x - greenZone.anchoredPosition.x);
        bool success = dist < successRange;

        int qty = targetItem.quantity;
        if (success) qty *= 2;

        inventory.AddItem(targetItem.item, qty);
        Destroy(targetItem.gameObject);

        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
