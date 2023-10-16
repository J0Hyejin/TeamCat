using UnityEngine;

public class BgMove : MonoBehaviour
{
    public Transform[] bg;
    public float speed = 2.7f;
    public float addSpeed = 0.3f;

<<<<<<< HEAD
    float poz = 6.6f;  //poz = start position
    float endPoz = -6.75f;
=======
<<<<<<< Updated upstream
    float                              poz = 9.25f;  //poz = start position, -poz = end position
=======
    float poz = -4f;  //poz = start position
    float endPoz = -5.45f;

    float width;

    private void Start()
    {
        bg[bg.Length - 1].position = new Vector3(poz, -0.98f, 0);
        for(int i = 0; i < bg.Length; i++)
        {
            bg[i].position = new Vector3(poz, -2.1f, 0);
        }
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].position += new Vector3(-(speed - i * addSpeed), 0, 0) * Time.fixedDeltaTime;

            if (i == 0)
                bg[i].position = new Vector3(poz, -2.19f, 0);
            else if (i > 0 && i < bg.Length - 2)
            {
                if (bg[i].position.x < endPoz)
                    bg[i].position = new Vector3(poz, -2.1f, 0);
            }
            else if (i == bg.Length - 2)
                bg[i].position = new Vector3(poz, -1, 0);
            else
                bg[i].position = new Vector3(poz, -0.98f, 0);
                if (bg[i].position.x < endPoz)
                    bg[i].position = new Vector3(poz, -0.3232f, 0);

        }
    }
}
