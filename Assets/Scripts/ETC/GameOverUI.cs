using System.Collections;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [Header("UI Text References")]
    public TMP_Text playTimeText;
    public TMP_Text grazeBonusText;
    public TMP_Text finalScoreText;

    [Header("New Record")]
    public GameObject newRecordObject;

    [Header("Settings")]
    public float countDuration = 0.4f;
    public float lineDelay = 0.2f;

    public void ShowGameOverUI(float playTime, int grazeCount, int baseScore)
    {
        gameObject.SetActive(true);
        StartCoroutine(GameOverSequence(playTime, grazeCount, baseScore));
    }

    private IEnumerator GameOverSequence(float playTime, int grazeCount, int baseScore)
    {
        playTimeText.text = "00:00";
        grazeBonusText.text = "0";
        finalScoreText.text = "0";
        if (newRecordObject != null) 
            newRecordObject.SetActive(false);

        yield return new WaitForSecondsRealtime(0.3f);

        int minutes = Mathf.FloorToInt(playTime / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);
        playTimeText.text = $"{minutes:00}:{seconds:00}";

        yield return new WaitForSecondsRealtime(lineDelay);

        int grazeBonus = grazeCount * 100;
        if (grazeBonusText != null)
        {
            yield return StartCoroutine(CountUpRoutine(grazeBonusText, 0, grazeBonus));
            yield return new WaitForSecondsRealtime(lineDelay);
        }

        int finalScore = baseScore + grazeBonus;
        yield return StartCoroutine(CountUpRoutine(finalScoreText, 0, finalScore, 0.6f));

        if (ScoreManager.instance != null)
        {
            bool isNewRecord = ScoreManager.instance.UpdateFinalScore(finalScore);
            if (isNewRecord && newRecordObject != null)
            {
                newRecordObject.SetActive(true);
            }
        }
    }

    private IEnumerator CountUpRoutine(TMP_Text textElement, int startValue, int targetValue, float customDuration = -1f)
    {
        float duration = customDuration > 0 ? customDuration : countDuration;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            int currentValue = (int)Mathf.Lerp(startValue, targetValue, timer / duration);
            textElement.text = currentValue.ToString("N0");
            yield return null;
        }

        textElement.text = targetValue.ToString("N0");
    }
}