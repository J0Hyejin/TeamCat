using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HYJ : MonoBehaviour
{
    public float speed = 10.0f;      // 이동 속도
    public GameObject pigeonPrefab;   // 프리팹
    public GameObject Soul;           //구슬 프리팹
    private bool isMoving = false;  // 이동 여부를 나타내는 플래그
    private GameObject newPigeon;     // 생성된 비둘기 저장할 변수
    private GameObject newPigeon1;     // 생성된 비둘기 저장할 변수
    private GameObject newPigeon2;     // 생성된 비둘기 저장할 변수

    public Vector3[] flightPositions; // 비둘기가 날아갈 위치들

    private float destroyTime = 6.0f; // 비둘기 삭제할 시간

    void Start()
    {
        isMoving = false;  // 시작할 때 이동을 비활성화

        // 비둘기가 날아갈 위치 초기화
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
            // isMoving이 활성화되고 newPigeon가 존재하는 경우에만 Gugu를 왼쪽으로 이동
            newPigeon.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (isMoving && newPigeon1 != null)
        {
            // isMoving이 활성화되고 newPigeon가 존재하는 경우에만 Gugu를 왼쪽으로 이동
            newPigeon1.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (isMoving && newPigeon2 != null)
        {
            // isMoving이 활성화되고 newPigeon가 존재하는 경우에만 Gugu를 왼쪽으로 이동
            newPigeon2.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player와 충돌하면 이동 활성화
            isMoving = true;

            // 랜덤한 위치 선택                
            //Vector3 randomPosition = flightPositions[Random.Range(0, flightPositions.Length)];

            // Gugu 프리팹을 생성하고 선택한 위치로 이동
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
               
            
            // 일정 시간 후에 Gugu를 삭제
            StartCoroutine(DestroyGuguAfterTime(destroyTime));
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Wall과 충돌하면 이동 비활성화
            isMoving = false;
        }
    }

    // 일정 시간 후에 비둘기를 삭제하는 코루틴
    private IEnumerator DestroyGuguAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (newPigeon != null)
        {
            Destroy(newPigeon);
        }
    }
}

