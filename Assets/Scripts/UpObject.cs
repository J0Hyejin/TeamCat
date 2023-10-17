using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObject : MonoBehaviour
{
    [SerializeField]
    GameObject Trap;

    [SerializeField]
    float yPosition = -2.751f;
    float speed = 12f;

    private bool isOnTrap = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (isOnTrap)
        {
            // 현재 위치에서 Y 좌표만 이동
            Vector3 newPosition = new Vector3(Trap.transform.position.x, yPosition, Trap.transform.position.z);
            Trap.transform.position = Vector3.MoveTowards(Trap.transform.position, newPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrap = true;
        }
    }
}
