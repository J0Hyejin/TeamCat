using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    GameObject[] panels; //MainButton, GameStart, HowToPlay, Gallery, Option

    Vector3 onPoz = new Vector3(0, -80, 0);
    Vector3 offPoz = new Vector3(0, -1120, 0);

    private void Start()
    {
        OnAppear(0);
    }

    public void OnGameStart()
    {
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

<<<<<<< Updated upstream

=======
    public void OnAppear(int pan)
    {
        panels[pan].transform.localPosition = onPoz;

    }
>>>>>>> Stashed changes

    public void Dissappear(int pan)
    {
        panels[pan].transform.localPosition = offPoz;
    }
}
