using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialCartoon : MonoBehaviour
{
    public GameObject toonPanel;

    private void Start()
    {
        StartCoroutine("StartCartoon");
    }

    IEnumerator StartCartoon()
    {
        toonPanel.SetActive(true);

        toonPanel.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.3f);
        float poz = 0;

        while(toonPanel.transform.localPosition.y < 3000)
        {
            poz++;
            toonPanel.transform.localPosition = new Vector3(0, poz, 0);
            yield return new WaitForSeconds(0.003f);
        }

        yield return new WaitForSeconds(1.3f);
        goTime();
    }

    public void goTime()
    {
        SceneManager.LoadScene("Tuto");
    }

    
}
