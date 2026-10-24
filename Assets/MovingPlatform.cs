using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public float distance = 3f;
    public float speed = 2f;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float movement = Mathf.PingPong(
            Time.time * speed,
            distance
        );

        transform.position = startPosition
            + Vector2.right * movement;
    }
}
