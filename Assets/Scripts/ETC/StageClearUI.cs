using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageClearUI : MonoBehaviour
{
    [Header("UI Text")]
    public TMP_Text clearTimeText;
    public TMP_Text grazeCountText;
    public TMP_Text lifeBonusText;
    public TMP_Text bombBonusText;
    public TMP_Text totalScoreText;

    public GameObject highScore;

    [Header("세팅 값")]
    public float lineCountDuration;
    public float delay;

    public void ShowClearUI(float stageTime, int grazeCount, int remainingLives, int remainingBombs, int baseScore)
    {
        gameObject.SetActive(true);
        StartCoroutine(ClearSequence(stageTime, grazeCount, remainingLives, remainingBombs, baseScore));
    }

    IEnumerator ClearSequence(float stageTime, int grazeCount, int remainingLives, int remainingBombs, int baseScore)
    {
        clearTimeText.text = "00:00";
        grazeCountText.text = "0";
        lifeBonusText.text = "0";
        bombBonusText.text = "0";
        totalScoreText.text = "0";

        yield return new WaitForSeconds(0.5f);

        int minutes = (int)(stageTime / 60);
        int seconds = (int)(stageTime % 60);
        clearTimeText.text = $"{minutes:00}:{seconds:00}";
        yield return new WaitForSecondsRealtime(delay);

        int grazeBonus = grazeCount * 200;
        if (grazeCount > 0)
        {
            yield return StartCoroutine(CountUpRoutine(grazeCountText, 0, grazeBonus));
            yield return new WaitForSecondsRealtime(delay);
        }
        
        int lifeBonus = remainingLives * 10000;
        if (remainingLives > 0)
        {
            yield return StartCoroutine(CountUpRoutine(lifeBonusText, 0, lifeBonus));
            yield return new WaitForSecondsRealtime(delay);
        }

        int bombBonus = remainingBombs * 5000;
        if (remainingBombs > 0)
        {
            yield return StartCoroutine(CountUpRoutine(bombBonusText, 0, bombBonus));
            yield return new WaitForSecondsRealtime(delay);
        }

        int totalScore = baseScore + grazeBonus + lifeBonus + bombBonus;
        
        yield return StartCoroutine(CountUpRoutine(totalScoreText, 0, totalScore, 0.8f));

        bool isNewRecord = ScoreManager.instance.UpdateFinalScore(totalScore);

        if (isNewRecord)
        {
            SoundManager.instance.HighScoreSound();
            highScore.SetActive(true);
        }
    }

    private IEnumerator CountUpRoutine(TMP_Text textElement, int startValue, int targetValue, float customDuration = -1f)
    {
        float duration = customDuration > 0 ? customDuration : lineCountDuration;
        float timer = 0f;

        float lastSoundTime = 0;
        float soundInterval = 0.04f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            int currentValue = (int)Mathf.Lerp(startValue, targetValue, timer / duration);

            textElement.text = currentValue.ToString("N0");

            if (timer - lastSoundTime >= soundInterval)
            {
                SoundManager.instance.ScoreSound();
                lastSoundTime = timer;
            }

            yield return null;
        }

        // 오차 없도록 마지막 값 보장
        textElement.text = targetValue.ToString("N0");
    }
}
