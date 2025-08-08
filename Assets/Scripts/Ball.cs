using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 7.5f;
    
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        rigidbody.linearVelocity = new Vector2(1, 1).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            var ballDirection = -other.relativeVelocity;
            rigidbody.linearVelocity = new Vector2(ballDirection.x, -ballDirection.y);
        }

        if (other.gameObject.TryGetComponent<Paddle>(out var paddle))
        {
            float relativeY = other.contacts[0].point.y - paddle.transform.position.y;
            
            float hitFactor = relativeY / collider.bounds.extents.y;
            
            Vector2 newDirection = new Vector2(-transform.position.x, hitFactor).normalized;
            
            float currentSpeed = other.relativeVelocity.magnitude;
            
            rigidbody.linearVelocity = newDirection * currentSpeed;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO Set the score, reset the ball
    }
}
