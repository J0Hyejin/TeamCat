using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curveMove;

    float appearTIme = 0.5f;

    Vector3 upPoz = new Vector3(0, -110, 0);
    Vector3 downPoz = new Vector3(0, -1150, 0);

    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject howToPanel;
    public GameObject levelPanel;
    public GameObject galleryPanel;




    public void gameExit()
    {
        Application.Quit();
    }

    IEnumerator OnMove(Vector3 start, Vector3 end, GameObject obj)
    {
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / appearTIme;

            obj.GetComponent<Transform>().position = Vector3.Lerp(start, end, curveMove.Evaluate(percent));

            yield return null;
        }
    }

}
