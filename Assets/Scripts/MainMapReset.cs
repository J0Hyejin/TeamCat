using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMapReset : MonoBehaviour
{
    public GameObject diedPanel;

    public void MainReset()
    {
        SceneManager.LoadScene("HYJ");
        diedPanel.SetActive(false);
    }
}
