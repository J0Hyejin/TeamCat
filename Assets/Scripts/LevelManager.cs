using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Sprite[] levels;
    public GameObject img;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject warnPanel;
    public TextMeshProUGUI levelName;

    string[] lvNames = { "Tutorial", "Stage1", "Stage2", "Stage3" };

    int showingLv = 0;
    int nowLv = 0;
    int cleardLv = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("cleardLv"))
            cleardLv = PlayerPrefs.GetInt("cleardLv");
        else
            cleardLv = 0;
        Debug.Log("cleardLv" + cleardLv);
        leftButton.SetActive(false);
    }

    public void LevelSelect()
    {
        switch (nowLv)
        {
            case 0:
                SceneManager.LoadScene("Tuto");
                break;
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
        }
    }

    public void TempLevelUp()
    {
        cleardLv++;
        PlayerPrefs.SetInt("cleardLv", cleardLv);
    }

    public void RIghtClick()
    {
        if (nowLv != 3)
            nowLv++;
        Debug.Log(nowLv);
    }

    public void LeftClick()
    {
        if (nowLv != 0)
            nowLv--;
        Debug.Log(nowLv);
    }

    private void Update()
    {
        img.GetComponent<Image>().sprite = levels[nowLv];
        levelName.text = lvNames[nowLv];
        if (nowLv == 0)
            leftButton.SetActive(false);
        else
            leftButton.SetActive(true);
        if (nowLv == 3)
            rightButton.SetActive(false);
        else
            rightButton.SetActive(true);
        if (cleardLv < nowLv)
            warnPanel.SetActive(true);
        else
            warnPanel.SetActive(false);
    }
}