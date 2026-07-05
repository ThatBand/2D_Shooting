using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ChangeInGameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
