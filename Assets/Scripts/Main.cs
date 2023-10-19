using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    [SerializeField]
    GameObject[] panels; //MainButton, GameStart, HowToPlay, Gallery, Option
    [SerializeField]
    GameObject warning;

    Vector3 onPoz = new Vector3(0, -80, 0);
    Vector3 offPoz = new Vector3(0, -1120, 0);

    private void Start()
    {
        OnAppear(0);
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainScene");
    }

    
}
