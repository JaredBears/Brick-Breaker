using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{

    public UnityEvent fallEvent;


    // When the ball collides with the hole
    void OnCollisionEnter2D(Collision2D collision)
    {
        fallEvent.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
