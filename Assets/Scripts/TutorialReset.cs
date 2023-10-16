using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialReset : MonoBehaviour
{
    public GameObject diedPanel;

    public void TutoReset()
    {
        SceneManager.LoadScene("Tu");
        diedPanel.SetActive(false);
    }
}
