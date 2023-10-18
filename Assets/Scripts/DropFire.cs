using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFire : MonoBehaviour
{
    public GameObject FireObjectPrefab; // ������
    public float speed = 15.0f; // �̵� �ӵ�
    public float flySpeed = 5.0f; // �� �Ʒ� �̵� �ӵ�

    Vector3 spawnPosition = new Vector3(10f, 4f, 0);
    bool isGoingUp = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject bird = Instantiate(FireObjectPrefab, spawnPosition, Quaternion.Euler(0, 0, 45));

            // ���� �̵�
            StartCoroutine(MoveObject(bird));
        }
    }

    IEnumerator MoveObject(GameObject bird)
    {
        while (bird != null)
        {
            // Y�� �̵�
            if (isGoingUp)
                bird.transform.Translate(Vector3.up * flySpeed * Time.deltaTime);

            // X�� �̵�
            bird.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }
}
