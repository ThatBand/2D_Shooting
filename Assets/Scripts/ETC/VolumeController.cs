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
    public Slider sgxSlider;

    // Start is called before the first frame update
    void Start()
    {
        masterSlider.onValueChanged.AddListener(SetMaserVol);
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sgxSlider.onValueChanged.AddListener(SetSfxVol);
    }

    public void SetMaserVol(float value)
    {
        if (value <= 0.001f)
            audioMixer.SetFloat("MasterVOL", -80f);

        else
            audioMixer.SetFloat("MasterVOL", Mathf.Log10(value) * 20);
    }

    public void SetBgmVol(float value)
    {
        if (value <= 0.001f)
            audioMixer.SetFloat("BgmVOL", -80f);

        else
            audioMixer.SetFloat("BgmVOL", Mathf.Log10(value) * 20);
    }

    public void SetSfxVol(float value)
    {
        if(value <= 0.001f)
            audioMixer.SetFloat("SfxVOL", -80f);

        else
            audioMixer.SetFloat("SfxVOL", Mathf.Log10(value) * 20);
    }
}
