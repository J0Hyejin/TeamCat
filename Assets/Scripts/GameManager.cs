using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject             GameMap;

    public GameObject     diedPanel;
    Vector3                    dirr = new Vector3(-1, 0, 0);

    int cleardLv = 0;
    int[] orbs;

    bool flag = false;

    
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
    }

    private void FixedUpdate()
    {
        GameMap.transform.Translate(dirr * speed * Time.fixedDeltaTime);
        StartCoroutine("AddSpeed");
    }


    public void OnDead()
    {
        diedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LevelClear()
    {

    }

    IEnumerator AddSpeed()
    {
        if (!flag)
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
