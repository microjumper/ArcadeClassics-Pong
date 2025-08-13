using Models;
using Strategy;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallData RuntimeBallData => ball.BallData;
    
    [SerializeField]
    private BallData ballDataTemplate;
    
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
        ball = new Ball(Instantiate(ballDataTemplate));

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
        transform.position = Vector2.zero;
        
        ball.BallData.speed = ballDataTemplate.speed;
        ball.Direction = ball.RandomizeDirection();
        
        rigidbody.linearVelocity = ball.Direction * ball.BallData.speed;
    }
    
    private void ResetBall()
    {
        Launch();
    }
}
