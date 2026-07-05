using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public UIManager uiManager;
    public int score;

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
        uiManager.UpdateScore(this.score);
    }
}