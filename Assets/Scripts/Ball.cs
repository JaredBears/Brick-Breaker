using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // The speed of the ball
    [SerializeField] float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        var rb = GetComponent<Rigidbody2D>();
        // Set the velocity of the ball to a normalized vector (1, 1) multiplied by the speed
        rb.velocity = Vector2.one.normalized * speed;
    }
}
