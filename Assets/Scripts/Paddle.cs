using Controllers;
using UnityEngine;

[RequireComponent(typeof(IController))]
public class Paddle : MonoBehaviour
{
    [SerializeField]
    private PaddleData paddleData;

    // References to components
    private new Rigidbody2D rigidbody;
    private IController controller;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<IController>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        var targetPosition = rigidbody.position;
        var targetY = rigidbody.position.y + paddleData.speed * Time.fixedDeltaTime * controller.GetVerticalInput();
        targetPosition.y = Mathf.Clamp(targetY, paddleData.bounds.Lower, paddleData.bounds.Upper);
        
        rigidbody.MovePosition(targetPosition);
    }
}
