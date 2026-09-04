using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public Button startButton;

    public Vector2 hiddenPos = new Vector2(0, 10000);
    public Vector2 visiblePos = new Vector2(0, 0);

    public float dur = 1;

    public PlayerIntro playerIntro;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.anchoredPosition = hiddenPos;
        menuPanel.gameObject.SetActive(true);
        StartCoroutine(MoveMenu(hiddenPos, visiblePos));
    }

    public void Click()
    {
        startButton.interactable = false;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return StartCoroutine(MoveMenu(visiblePos, hiddenPos));
        
        yield return StartCoroutine(playerIntro.FlyInSequence());

        GameManager.instance.GameStart();
    }

    private IEnumerator MoveMenu(Vector2 start, Vector2 end)
    {
        float timer = 0;

        while (timer < dur)
        {
            timer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, timer / dur);
            menuPanel.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        menuPanel.anchoredPosition = end;
    }
}
