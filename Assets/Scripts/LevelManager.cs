using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public Sprite[] levels;
    public GameObject img;
    public GameObject leftButton;
    public GameObject rightButton;
    public TextMeshProUGUI levelName;

    public void TutoClick()
    {
        SceneManager.LoadScene("Tuto");
    }
}
