using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObjectUpDown : MonoBehaviour
{
    public GameObject flyObjectPrefab; // 프리팹
    public float speed = 15.0f; // 이동 속도
    public float flySpeed = 5.0f; // 위 아래 이동 속도

    Vector3 spawnPosition = new Vector3(12, 0.1f, 0);
    float minY = -3.2f;
    float maxY = 3.0f;
    bool isGoingUp = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject bird = Instantiate(flyObjectPrefab, spawnPosition, Quaternion.identity);

            // 새를 이동
            StartCoroutine(MoveObject(bird));
        }
    }

    IEnumerator MoveObject(GameObject bird)
    {
        while (bird != null)
        {
            // Y축 이동
            if (isGoingUp)
            {
                bird.transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
                if (bird.transform.position.y >= maxY)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                bird.transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
                if (bird.transform.position.y <= minY)
                {
                    isGoingUp = true;
                }
            }

            // X축 이동
            bird.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }
}
