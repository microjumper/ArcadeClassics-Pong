using System;
using Models;
using Strategy;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private BallData ballData;
    
    // Components
    private new Rigidbody2D rigidbody;
    
    // Local variables
    private Ball ball;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ball = new Ball(ballData);

        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IBounceBehaviorProvider>(out var bounceProvider))
        {
            bounceProvider.BounceBehaviour.Bounce(ball, other);
        }

        rigidbody.linearVelocity = ball.Direction * ball.BallData.speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall();
    }
    
    private void Launch()
    {
        ball.Direction = ball.RandomizeDirection();
        
        rigidbody.linearVelocity = ball.Direction * ball.BallData.speed;
    }
    
    private void ResetBall()
    {
        Launch();
    }
}
