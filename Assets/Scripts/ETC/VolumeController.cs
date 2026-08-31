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


    // Start is called before the first frame update
    void Start()
    {
        masterSlider.onValueChanged.AddListener(SetMaserVol);
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);

        masterSlider.value = PlayerPrefs.GetFloat("MasterVol", 0.5f);
        bgmSlider.value = PlayerPrefs.GetFloat("BgmVol", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVol", 0.5f);

        masterSize.text = masterSlider.value.ToString("F2");
        bgmSize.text = bgmSlider.value.ToString("F2");
        sfxSize.text = sfxSlider.value.ToString("F2");
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
        if(value <= 0.001f)
            audioMixer.SetFloat("SfxVOL", -80f);

        else
            audioMixer.SetFloat("SfxVOL", Mathf.Log10(value) * 20);

        sfxSize.text = sfxSlider.value.ToString("F2");

        PlayerPrefs.SetFloat("SfxVol", value);
    }
}
