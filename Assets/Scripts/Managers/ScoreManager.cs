using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public UIManager uiManager;
    public int score;
    public int totalScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ScorePlus(int value)
    {
        this.score += value;
        totalScore += score;
        uiManager.UpdateScore(this.score);
    }

    public void TotalScorePlus(int value)
    {
        this.totalScore += value;

    }
}