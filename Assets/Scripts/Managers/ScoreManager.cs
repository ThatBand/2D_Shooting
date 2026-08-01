using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public UIManager uiManager;

    [Header("점수 설정")]
    public int curScore;
    public int highScore;

    public int totalScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ScorePlus(int value)
    {
        this.curScore += value;
        totalScore += curScore;

        if (curScore > highScore)
        {
            highScore = curScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        uiManager.UpdateCurrentScore(this.curScore, highScore);
    }

    public void TotalScorePlus(int value)
    {
        this.totalScore += value;

    }
}