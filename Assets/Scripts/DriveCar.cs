using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public GameObject carPrefab; // 자동차 프리팹
    [SerializeField]
    public float speed = 5.0f; // 자동차 이동 속도
    Vector3 spawnPosition = new Vector3(10, -3.5f, 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Wall 위에 자동차를 생성
            GameObject car = Instantiate(carPrefab, spawnPosition, Quaternion.identity);

            // 자동차를 이동
            StartCoroutine(MoveCar(car));

            // 4초 후에 자동차를 삭제
            Destroy(car, 4.0f);
        }
    }

    IEnumerator MoveCar(GameObject car)
    {
        while (car != null)
        {
            car.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }
}
