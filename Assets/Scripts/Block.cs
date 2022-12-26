using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    // The colors of the block based on its health
    static Color[] colors = {
        Color.yellow,
        new Color(1f, 0.5f, 0f), // Orange
        Color.red
    };

    // The maximum health of the block
    public static int maxHealth = colors.Length - 1;

    // The health of the block
    public int health = 2;

    public UnityEvent destroyedEvent;

    // Match the color of the block to its health
    void MatchColor()
    {
        var colorIndex = Mathf.Clamp(health, 0, maxHealth);
        GetComponent<SpriteRenderer>().color = colors[colorIndex];
    }

    void Start()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        MatchColor();
    }

    // When the block collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            health--;
            MatchColor();
        }
        else
        {
            destroyedEvent.Invoke();
            Destroy(gameObject);
        }
    }   
}
