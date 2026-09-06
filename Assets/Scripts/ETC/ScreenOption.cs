using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenOption : MonoBehaviour
{
    public TextMeshProUGUI text;

    private bool isFullScreen;

    // Start is called before the first frame update
    private void Start()
    {
        isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 0) == 1;

        ApplyScreenMode();
    }

    // 화면 모드 버튼 OnClick() 이벤트에 연결할 함수
    public void ToggleScreenMode()
    {
        SoundManager.instance.ButtonClickSound();

        isFullScreen = !isFullScreen;

        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();

        ApplyScreenMode();
    }

    private void ApplyScreenMode()
    {
        if (isFullScreen)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        else
            Screen.SetResolution(1024, 768, FullScreenMode.Windowed);

        text.text = isFullScreen ? "전체화면" : "창모드";
    }
}
