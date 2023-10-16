using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObject : MonoBehaviour
{
    public float speed = 10.0f;      // �̵� �ӵ�
    public GameObject pigeonPrefab;   // ������
    private bool isMoving = false;  // �̵� ���θ� ��Ÿ���� �÷���
    private GameObject newPigeon;     // ������ ��ѱ� ������ ����

    public Vector3[] flightPositions; // ��ѱⰡ ���ư� ��ġ��

    private float destroyTime = 6.0f; // ��ѱ� ������ �ð�

    void Start()
    {
        isMoving = false;  // ������ �� �̵��� ��Ȱ��ȭ

        // ��ѱⰡ ���ư� ��ġ �ʱ�ȭ
        flightPositions = new Vector3[]
        {
            new Vector3(12, -2.5f, 0),
            new Vector3(12, -1.1f, 0),
            new Vector3(12, 0.25f, 0)
        };
    }

    void Update()
    {
        if (isMoving && newPigeon != null)
        {
            // isMoving�� Ȱ��ȭ�ǰ� newPigeon�� �����ϴ� ��쿡�� Gugu�� �������� �̵�
            newPigeon.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player�� �浹�ϸ� �̵� Ȱ��ȭ
            isMoving = true;

            // ������ ��ġ ����
            Vector3 randomPosition = flightPositions[Random.Range(0, flightPositions.Length)];

            // Gugu �������� �����ϰ� ������ ��ġ�� �̵�
            newPigeon = Instantiate(pigeonPrefab, randomPosition, Quaternion.identity);

            // ���� �ð� �Ŀ� Gugu�� ����
            StartCoroutine(DestroyGuguAfterTime(destroyTime));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Wall�� �浹�ϸ� �̵� ��Ȱ��ȭ
            isMoving = false;
        }
    }

    // ���� �ð� �Ŀ� ��ѱ⸦ �����ϴ� �ڷ�ƾ
    private IEnumerator DestroyGuguAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (newPigeon != null)
        {
            Destroy(newPigeon);
        }
    }
}
