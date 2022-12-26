using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float maxOffset = 1.5f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world space
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var position = rb.position;
        // Clamp the x position of the paddle to the max offset
        position.x = Mathf.Clamp(target.x, -maxOffset, maxOffset);
        // Set the position of the paddle
        rb.MovePosition(position);
    }
}