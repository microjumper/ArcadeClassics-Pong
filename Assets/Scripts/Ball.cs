using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private BallData ballData;
    
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    
    private float speed;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Start() => Launch();
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            HandleWallCollision(other);
            
            return;
        }
        
        if (other.gameObject.TryGetComponent<Paddle>(out _))
        {
            HandlePaddleCollision(other);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoalLine"))
        {
            transform.position = Vector2.zero;
        
            Launch();
        }
    }

    private void Launch()
    {
        speed = ballData.speed;
        
        var bounceAngleInRadians = ballData.maxBounceAngleInDegrees * Mathf.Deg2Rad;
        var angle = Random.Range(-bounceAngleInRadians, bounceAngleInRadians);
        
        rigidbody.linearVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * speed;
    }
    
    private void HandleWallCollision(Collision2D collision)
    {
        var incoming = -collision.relativeVelocity;
        var normal = collision.contacts[0].normal;
        
        var reflected = Vector2.Reflect(incoming, normal);

        rigidbody.linearVelocity = reflected.normalized * incoming.magnitude;
    }

    private void HandlePaddleCollision(Collision2D collision)
    {
        var paddleCenter = collision.collider.bounds.center;
        var ballCenter = collider.bounds.center;

        var yOffset = ballCenter.y - paddleCenter.y;
        
        var normalizedRelativeY = Mathf.Clamp(yOffset / collision.collider.bounds.extents.y, -1f, 1f);

        var bounceAngleInRadians = normalizedRelativeY * ballData.maxBounceAngleInDegrees * Mathf.Deg2Rad;
        
        var direction = Mathf.Sign(collision.GetContact(0).normal.x);
        
        var newSpeed = Mathf.Clamp(speed * ballData.speedIncrease, ballData.speed, ballData.maxSpeed);
            
        var newVelocity = new Vector2(Mathf.Cos(bounceAngleInRadians) * direction, Mathf.Sin(bounceAngleInRadians)) * newSpeed;
        
        rigidbody.linearVelocity = newVelocity;
    }
}
