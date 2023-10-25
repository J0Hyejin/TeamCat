using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameManager;

    bool isDead = false;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        isDead = gameManager.GetComponent<GameManager>().isDead;
        if (isDead)
            this.gameObject.SetActive(false);
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnResume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        this.gameObject.SetActive(true);
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
