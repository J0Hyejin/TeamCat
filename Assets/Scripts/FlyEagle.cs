using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEagle : MonoBehaviour
{
    public float speed = 15.0f;      // �̵� �ӵ�
    public GameObject eaglePrefab;   // ������
    private bool isMoving = false;  // �̵� ���θ� ��Ÿ���� �÷���
    private GameObject newEagle;     // ������ ������ ������ ����

    public Vector3[] flightPositions; // �������� ���ư� ��ġ��

    private float destroyTime = 4.0f; // ������ ������ �ð�

    void Start()
    {
        isMoving = false;  // ������ �� �̵��� ��Ȱ��ȭ

        // �������� ���ư� ��ġ �ʱ�ȭ
        flightPositions = new Vector3[]
        {
            new Vector3(10, -2.5f, 0),
            new Vector3(10, -3.5f, 0)
        };
    }

    void Update()
    {
        if (isMoving && newEagle != null)
        {
            // isMoving�� Ȱ��ȭ�ǰ� newPigeon�� �����ϴ� ��쿡�� Gugu�� �������� �̵�
            newEagle.transform.Translate(Vector3.left * speed * Time.deltaTime);
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

            // eagle �������� �����ϰ� ������ ��ġ�� �̵�
            newEagle = Instantiate(eaglePrefab, randomPosition, Quaternion.identity);

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

    // ���� �ð� �Ŀ� �������� �����ϴ� �ڷ�ƾ
    private IEnumerator DestroyGuguAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (newEagle != null)
        {
            Destroy(newEagle);
        }
    }
}