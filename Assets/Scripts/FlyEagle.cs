using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEagle : MonoBehaviour
{
    public float speed = 15.0f;      // 이동 속도
    public GameObject eaglePrefab;   // 프리팹
    private bool isMoving = false;  // 이동 여부를 나타내는 플래그
    private GameObject newEagle;     // 생성된 독수리 저장할 변수

    public Vector3[] flightPositions; // 독수리가 날아갈 위치들

    private float destroyTime = 4.0f; // 독수리 삭제할 시간

    void Start()
    {
        isMoving = false;  // 시작할 때 이동을 비활성화

        // 독수리가 날아갈 위치 초기화
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
            // isMoving이 활성화되고 newPigeon가 존재하는 경우에만 Gugu를 왼쪽으로 이동
            newEagle.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player와 충돌하면 이동 활성화
            isMoving = true;

            // 랜덤한 위치 선택
            Vector3 randomPosition = flightPositions[Random.Range(0, flightPositions.Length)];

            // eagle 프리팹을 생성하고 선택한 위치로 이동
            newEagle = Instantiate(eaglePrefab, randomPosition, Quaternion.identity);

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

    // 일정 시간 후에 독수리를 삭제하는 코루틴
    private IEnumerator DestroyGuguAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (newEagle != null)
        {
            Destroy(newEagle);
        }
    }
}