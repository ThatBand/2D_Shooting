using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("점수 설정")]
    public int stageScore;
    public int grazeScore;
    public int highScore;

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
        UIManager.instance.UpdateCurrentScore(stageScore, highScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.Save();

            highScore = 0;

            UIManager.instance.UpdateCurrentScore(stageScore, highScore);
        }
    }

    public void GrazeScorePlus(int value)
    {
        grazeScore += value;
    }

    public void ScorePlus(int value)
    {
        this.stageScore += value;

        if (stageScore > highScore)
        {
            highScore = stageScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UIManager.instance.UpdateCurrentScore(this.stageScore, highScore);
    }

    public bool UpdateFinalScore(int value)
    {
        stageScore = value;

        if (stageScore > highScore)
        {
            highScore = stageScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            UIManager.instance.UpdateCurrentScore(stageScore, highScore);
            return true;
        }

        return false;
    }
}