using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

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

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        UIManager.instance.UpdateCurrentScore(curScore, highScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.Save();

            highScore = 0;

            UIManager.instance.UpdateCurrentScore(curScore, highScore);
        }
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

        UIManager.instance.UpdateCurrentScore(this.curScore, highScore);
    }

    public void TotalScorePlus(int value)
    {
        this.totalScore += value;

    }
}