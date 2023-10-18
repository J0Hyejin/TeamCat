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

    IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(addTime);
        gameSpeed += addSpeed;
        Time.timeScale = gameSpeed;
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
