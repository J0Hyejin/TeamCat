using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
    public GameObject EndPanel;

    public void OnReset()
    {
        Debug.Log("ResetClick");
        SceneManager.LoadScene("Tutorial");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            EndPanel.SetActive(true);   

        }
    }

    public void BackMain()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
}
