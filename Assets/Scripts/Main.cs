using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Main : MonoBehaviour
{
    [SerializeField]
    GameObject[] panels; //MainButton, GameStart, HowToPlay, Gallery, Option
    [SerializeField]
    GameObject warning;
    public TextMeshProUGUI soulsText;


    Vector3 onPoz = new Vector3(0, -80, 0);
    Vector3 offPoz = new Vector3(0, -1120, 0);

    int souls;

    private void Start()
    {
        OnAppear(0);

        string[] temp;
        if (!PlayerPrefs.HasKey("Soul"))
            souls = 0;
        else
        {
            temp = PlayerPrefs.GetString("Soul").Split(',');
            for (int i = 0; i < 9; i++)
                souls += int.Parse(temp[i]);
        }
        soulsText.text = "Collected soul: " + souls;
    }

    public void OnGameStart()
    {
        if (!PlayerPrefs.HasKey("NewBee"))
        {
            SceneManager.LoadScene("TutoCartoon");
            PlayerPrefs.SetInt("NewBee", 1);
        }
        else if (PlayerPrefs.GetInt("cleardLv") == 0)
            SceneManager.LoadScene("Tuto");

        Dissappear(0);
        OnAppear(1);
    }

    public void OffGameStart()
    {
        Dissappear(1);
        OnAppear(0);
    }

    public void OnHow()
    {
        Dissappear(0);
        OnAppear(2);
    }

    public void OffHow()
    {
        Dissappear(2);
        OnAppear(0);
    }

    public void OnGallery()
    {
        Dissappear(0);
        OnAppear(3);
    }

    public void OffGallery()
    {
        Dissappear(3);
        OnAppear(0);
    }

    public void OnOption()
    {
        Dissappear(0);
        OnAppear(4);
    }

    public void OffOption()
    {
        Dissappear(4);
        OnAppear(0);
    }

    public void OnExit()
    {
        Application.Quit();
    }


    public void OnAppear(int pan)
    {
        panels[pan].transform.localPosition = onPoz;

    }

    public void Dissappear(int pan)
    {
        panels[pan].transform.localPosition = offPoz;
    }

    public void Warning()
    {
        warning.SetActive(true);
    }

    public void CloseWarn()
    {
        warning.SetActive(false);
    }

    public void GameReset()
    {
        // ���� ī�޶� ���� ���� �ʱ�ȭ
        AudioSource[] audioSources = Camera.main.GetComponents<AudioSource>(); // ���� ī�޶󿡼� AudioSource ��������
        foreach (AudioSource source in audioSources) // �� AudioSource�� ���� �ݺ�
        {
            source.Stop(); // ��� ���� ��� ���� ����
        }

        // SoundManager ������Ʈ ã��
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null)
        {
            AudioSource[] smAudioSources = soundManager.GetComponents<AudioSource>(); // SoundManager���� AudioSource ��������
            foreach (AudioSource source in smAudioSources) // �� AudioSource�� ���� �ݺ�
            {
                source.Stop(); // ��� ���� ��� ���� ����
            }
        }

        PlayerPrefs.DeleteAll(); // ��� �÷��̾� ȯ�� ���� ����
        // ���� �Ҹ� �ʱ�ȭ
        PlayerPrefs.SetFloat("SoundVolume", 0.5f); // �⺻ �Ҹ� ���� ����
        PlayerPrefs.SetFloat("MusicVolume", 0.5f); // �⺻ ���� ���� ����
        // �� �ٽ� �ε�
        SceneManager.LoadScene("MainScene"); // "MainScene" ������ �̵�
    }

    public void GoTutoScene()
    {
        if(PlayerPrefs.HasKey("TutoWatched"))
            SceneManager.LoadScene("TutoCartoon");
    }
    
}
