using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanelManager : MonoBehaviour
{
    public GameObject[] noticePanels;

    public Button prevBtn;
    public Button nextBtn;

    private int curPageIndex = 0;

    private void Start()
    {
        GameTimeManager.instance.StopGame();
        UpdatePage();
    }

    public void NextNotice()
    {
        if (curPageIndex < noticePanels.Length - 1)
        {
            curPageIndex++;
            UpdatePage();
        }
    }

    public void PrevNotice()
    {
        if (curPageIndex > 0)
        {
            curPageIndex--;
            UpdatePage();
        }
    }

    public void CloseNotice()
    {
        gameObject.SetActive(false);
        GameTimeManager.instance.StartGame();
    }

    private void UpdatePage()
    {
        for (int i = 0; i < noticePanels.Length; i++)
        {
            noticePanels[i].SetActive(false);
        }

        noticePanels[curPageIndex].SetActive(true);

        prevBtn.gameObject.SetActive(curPageIndex > 0);
        nextBtn.gameObject.SetActive(curPageIndex < noticePanels.Length - 1);
    }
}
