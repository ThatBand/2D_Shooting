using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public static bool isAutoStart = false;

    [Header("UI 설정")]
    public RectTransform menuPanel;
    public Button startButton;

    [Header("UI 위치")]
    public Vector2 hiddenPos = new Vector2(0, 1000);
    public Vector2 visiblePos = new Vector2(0, 0);

    [Header("연출 시간")]
    public float dur = 1;

    [Header("플레이어 연출 이동")]
    public PlayerIntro playerIntro;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        menuPanel.gameObject.SetActive(true);

        if (isAutoStart)
        {
            isAutoStart = false;
            
            menuPanel.anchoredPosition = hiddenPos;
            
            StartCoroutine(StartGame());
        }

        else
        {
            menuPanel.anchoredPosition = hiddenPos;
            StartCoroutine(MoveMenu(hiddenPos, visiblePos));
        }
    }

    public void Click()
    {
        SoundManager.instance.ButtonClickSound();

        startButton.interactable = false;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        if (menuPanel.anchoredPosition != hiddenPos)
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

    public static void RestartGame()
    {
        isAutoStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void GoToMainMenu()
    {
        isAutoStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
