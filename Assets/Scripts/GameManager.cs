using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject             GameMap;

    public GameObject           diedPanel;

    public TextMeshProUGUI   hp_;
    public TextMeshProUGUI   deadTxt;
    [SerializeField]
    GameObject             mouse_;
    [SerializeField]
    GameObject             dog_;

    Vector3                    dirr = new Vector3(0, 0, 0);
    
    [SerializeField]
    float                        speed = 12;
    [SerializeField]
    float addSpeed = 0.2f;
    [SerializeField]
    float addTime = 0.5f;
    float gameSpeed = 1;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {

        GameMap.transform.Translate(dirr * speed * Time.fixedDeltaTime);


    }


    public void GameStart()
    {

    }

    public void OnPeopel()
    {
        Debug.Log("Human Touched");
        Time.timeScale = 0;
    }

    public void OnFall()
    {
        Debug.Log("Fallen");
        Time.timeScale = 0;
    }

    public void ReStart()
    {
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            Debug.Log("Turorial Reset");
            SceneManager.LoadScene("Tutorial");

        }
        
    }

    IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(addTime);
        gameSpeed += addSpeed;
        Time.timeScale = gameSpeed;
    }
}
