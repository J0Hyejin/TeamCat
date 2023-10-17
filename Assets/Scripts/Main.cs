using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curveMove;

    float appearTIme = 0.5f;

    Vector3 upPoz = new Vector3(0, -110, 0);
    Vector3 downPoz = new Vector3(0, -1150, 0);

    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject howToPanel;
<<<<<<< Updated upstream
    public GameObject stageSelect;

    public void GameStartButton()
    {
        stageSelect.SetActive(true);
    }

    public void HowToPlay()
    {
        howToPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPanel.SetActive(false);
    }

    public void Option()
    {
        optionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
    }
=======
    public GameObject levelPanel;  
    public GameObject galleryPanel;

   

>>>>>>> Stashed changes

    public void gameExit()
    {
        Application.Quit();
    }



}
