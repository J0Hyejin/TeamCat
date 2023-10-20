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

        toonPanel.transform.localPosition = new Vector3(0, 37, 0);
        cartoon[0].SetActive(true); //scene1
        yield return new WaitForSeconds(1.3f);
        float poz = 37;

        while(toonPanel.transform.localPosition.y < 185)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        cartoon[1].SetActive(true); //scene 2
        poz = 185;
        while(toonPanel.transform.localPosition.y < 380)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.012f);
        }
        yield return new WaitForSeconds(1.3f);

        poz = 380;
        while(toonPanel.transform.localPosition.y < 466)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        cartoon[2].SetActive(true); //scne 3
        yield return new WaitForSeconds(1.3f);

        poz = 466;
        while(toonPanel.transform.localPosition.y < 800)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.008f);
        }
        cartoon[3].SetActive(true);
        yield return new WaitForSeconds(1.3f);
       
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
