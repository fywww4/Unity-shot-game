using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousVelocity : MonoBehaviour
{
    // The Velocity
    public Vector2 velocity;
    public int pointValue = 10;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            // 加分
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(pointValue);
            }

            // 銷毀敵機和子彈
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

