using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject howToPanel;
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

    public void gameExit()
    {
        Application.Quit();
    }
}
