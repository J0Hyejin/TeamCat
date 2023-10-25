using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public AudioSource musicsource;
    public Slider slider;
    float volume;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
            volume = 0.5f;
        else
            volume = PlayerPrefs.GetFloat("volume");
        slider.value = volume;
        SetMusicVolume(volume);
        DontDestroyOnLoad(transform.gameObject);
        tmpro.text = "Sound\n" + (volume * 100).ToString("F0") + "%";
    }
    public void SetMusicVolume(float v)
    {
        volume = v;
        musicsource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    private void Update()
    {
        tmpro.text = "Sound\n" + (volume * 100).ToString("F0") + "%";
    }
}
