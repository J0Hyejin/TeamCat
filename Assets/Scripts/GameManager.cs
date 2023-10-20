using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject             GameMap;
    public GameObject FinishPanel;
    public TextMeshProUGUI orbText;
    public TextMeshProUGUI diedOrbText;

    public GameObject     diedPanel;
    Vector3                    dirr = new Vector3(-1, 0, 0);

    [SerializeField]
    int currentLv = 0;
    int cleardLv = 0;
    int[] orbs = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    bool flag = false;
    public bool isDead = false;

    
    [SerializeField]
    float  speed = 12;
    [SerializeField]
    float addSpeed = 0.2f;
    [SerializeField]
    float addTime = 0.5f;
    float gameSpeed = 1;

    private void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.HasKey("cleardLv"))
            cleardLv = PlayerPrefs.GetInt("cleardLv");
        else
            cleardLv = 0;

        if (!PlayerPrefs.HasKey("Soul"))
            PlayerPrefs.SetString("Soul", "0,0,0,0,0,0,0,0,0");

        isDead = false;
    }

    private void FixedUpdate()
    {
        GameMap.transform.Translate(dirr * speed * Time.fixedDeltaTime);
        StartCoroutine("AddSpeed");
    }


    public void OnDead()
    {
        diedPanel.SetActive(true);
        isDead = true;
        Time.timeScale = 0;
        OrbCount();
        OrbText();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void NextLevel()
    {
        switch (currentLv+1)
        {
            case 1:
                SceneManager.LoadScene("Stage1(LYS)");
                break;
            case 2:
                SceneManager.LoadScene("Stage2(HYJ)");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
        }
    }

    public void LevelClear()
    {
        FinishPanel.SetActive(true);
        isDead = true;
        Time.timeScale = 0;
        if(cleardLv == 3)
        {
            //compare orbs. 
        }
        else
            cleardLv++;
        PlayerPrefs.SetInt("cleardLv", cleardLv);
        OrbCount();
        OrbText(); 
    }

    void OrbCount()
    {
        string[] temp = PlayerPrefs.GetString("Soul").Split(',');
        for (int i = 0; i < 9; i++)
            orbs[i] = int.Parse(temp[i]);
    }

    void OrbText()
    {
        string temp = "";
        switch (currentLv)
        {
            case 0:
                temp = orbs[0] + "/ 1";
                break;
            case 1:
                temp = orbs[1] + orbs[2] + "/ 2";
                break;
            case 2:
                temp = orbs[3] + orbs[4] + orbs[5] + "/ 3";
                break;
            case 3:
                temp = orbs[6] + orbs[7] + orbs[8] + "/ 3";
                break;
        }
        diedOrbText.text = temp;
        orbText.text = temp;
    }

    IEnumerator AddSpeed()
    {
        if (!flag && !isDead)
        {
            flag = true;
            yield return new WaitForSeconds(addTime);
            gameSpeed += addSpeed;
            Time.timeScale = gameSpeed;
            Debug.Log("Add speed, Now Speed: "+ gameSpeed);
            flag = false;
        }
    }
}
