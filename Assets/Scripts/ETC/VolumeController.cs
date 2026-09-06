using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("오디오 믹서")]
    public AudioMixer audioMixer;

    [Header("UI 슬라이더")]
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    [Header("볼륨 사이즈")]
    public TextMeshProUGUI masterSize;
    public TextMeshProUGUI bgmSize;
    public TextMeshProUGUI sfxSize;

    private void Awake()
    {
        // 이벤트 리스너 등록은 스크립트가 로드될 때 딱 한 번만 수행
        masterSlider.onValueChanged.AddListener(SetMaserVol);
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);
    }

    // 설정창(GameObject)이 SetActive(true)로 열릴 때마다 매번 실행됨
    private void OnEnable()
    {
        // 저장된 최신 PlayerPrefs 값을 가져와서 슬라이더 및 믹서 동기화
        float master = PlayerPrefs.GetFloat("MasterVol", 0.3f);
        float bgm = PlayerPrefs.GetFloat("BgmVol", 0.3f);
        float sfx = PlayerPrefs.GetFloat("SfxVol", 0.3f);

        masterSlider.value = master;
        bgmSlider.value = bgm;
        sfxSlider.value = sfx;

        // 슬라이더 값 변경에 따른 UI 텍스트 및 오디오 믹서 최신화
        SetMaserVol(master);
        SetBgmVol(bgm);
        SetSfxVol(sfx);
    }

    public void SetMaserVol(float value)
    {
        if (value <= 0.001f)
            audioMixer.SetFloat("MasterVOL", -80f);
        else
            audioMixer.SetFloat("MasterVOL", Mathf.Log10(value) * 20);

        masterSize.text = masterSlider.value.ToString("F2");
        PlayerPrefs.SetFloat("MasterVol", value);
    }

    public void SetBgmVol(float value)
    {
        if (value <= 0.001f)
            audioMixer.SetFloat("BgmVOL", -80f);
        else
            audioMixer.SetFloat("BgmVOL", Mathf.Log10(value) * 20);

        bgmSize.text = bgmSlider.value.ToString("F2");
        PlayerPrefs.SetFloat("BgmVol", value);
    }

    public void SetSfxVol(float value)
    {
        if (value <= 0.001f)
            audioMixer.SetFloat("SfxVOL", -80f);
        else
            audioMixer.SetFloat("SfxVOL", Mathf.Log10(value) * 20);

        sfxSize.text = sfxSlider.value.ToString("F2");
        PlayerPrefs.SetFloat("SfxVol", value);
    }
}