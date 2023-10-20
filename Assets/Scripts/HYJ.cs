using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HYJ : MonoBehaviour
{
    public float speed = 10.0f;      // �̵� �ӵ�
    public GameObject pigeonPrefab;   // ������
    public GameObject Soul;           //���� ������
    private bool isMoving = false;  // �̵� ���θ� ��Ÿ���� �÷���
    private GameObject newPigeon;     // ������ ��ѱ� ������ ����
    private GameObject newPigeon1;     // ������ ��ѱ� ������ ����
    private GameObject newPigeon2;     // ������ ��ѱ� ������ ����

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
        if (isMoving && newPigeon1 != null)
        {
            // isMoving�� Ȱ��ȭ�ǰ� newPigeon�� �����ϴ� ��쿡�� Gugu�� �������� �̵�
            newPigeon1.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (isMoving && newPigeon2 != null)
        {
            // isMoving�� Ȱ��ȭ�ǰ� newPigeon�� �����ϴ� ��쿡�� Gugu�� �������� �̵�
            newPigeon2.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player�� �浹�ϸ� �̵� Ȱ��ȭ
            isMoving = true;

            // ������ ��ġ ����                
            //Vector3 randomPosition = flightPositions[Random.Range(0, flightPositions.Length)];

            // Gugu �������� �����ϰ� ������ ��ġ�� �̵�
            int i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    newPigeon = Instantiate(Soul, flightPositions[0], Quaternion.identity);
                    newPigeon1 = Instantiate(pigeonPrefab, flightPositions[1], Quaternion.identity);
                    newPigeon2 = Instantiate(pigeonPrefab, flightPositions[2], Quaternion.identity);
                    break;
                case 1:
                    newPigeon = Instantiate(pigeonPrefab, flightPositions[0], Quaternion.identity);
                    newPigeon1 = Instantiate(Soul, flightPositions[1], Quaternion.identity);
                    newPigeon2 = Instantiate(pigeonPrefab, flightPositions[2], Quaternion.identity);
                    break;
                case 2:
                    newPigeon = Instantiate(pigeonPrefab, flightPositions[0], Quaternion.identity);
                    newPigeon1 = Instantiate(pigeonPrefab, flightPositions[1], Quaternion.identity);
                    newPigeon2 = Instantiate(Soul, flightPositions[2], Quaternion.identity);
                    break;

            }
               
            
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

