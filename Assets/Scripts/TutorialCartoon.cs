using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialCartoon : MonoBehaviour
{
    public GameObject[] cartoon;
    public GameObject toonPanel;

    private void Start()
    {
        StartCoroutine("StartCartoon");
    }

    IEnumerator StartCartoon()
    {

        toonPanel.SetActive(true);
        cartoon[0].SetActive(true); //scene1
        toonPanel.transform.localPosition = new Vector3(0, 37, 0);
        yield return new WaitForSeconds(1.3f);
        float poz = 37;
        cartoon[1].SetActive(true); //scene 2
        while(toonPanel.transform.localPosition.y < 185)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        poz = 185;
        while(toonPanel.transform.localPosition.y < 380)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.012f);
        }
        yield return new WaitForSeconds(1.3f);
        cartoon[2].SetActive(true); //scne 3
        poz = 380;
        while(toonPanel.transform.localPosition.y < 466)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        yield return new WaitForSeconds(1.3f);
        cartoon[3].SetActive(true);
        poz = 466;
        while(toonPanel.transform.localPosition.y < 800)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        yield return new WaitForSeconds(1.3f);
        toonPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        goTime();
    }

    void goTime()
    {
        if (!PlayerPrefs.HasKey("TutoWatched"))
        {
            SceneManager.LoadScene("Tuto");
            PlayerPrefs.SetInt("TutoWatched", 1);
        }
        else
            SceneManager.LoadScene("MainScene");
    }
}
