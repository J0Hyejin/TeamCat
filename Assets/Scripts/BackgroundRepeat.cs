using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 3.0f;
    [SerializeField] float posValue;

    Vector2 currentPos;
    float newPos;

    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = currentPos + Vector2.left * newPos;
    }
}
