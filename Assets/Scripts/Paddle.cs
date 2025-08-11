using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private PaddleData paddleData;

    // References to components
    private new Rigidbody2D rigidbody;
    
    // Local fields
    private float verticalInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        verticalInput = 0;
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        verticalInput = context.phase switch
        {
            InputActionPhase.Performed => context.ReadValue<float>(),
            InputActionPhase.Canceled => 0f,
            _ => verticalInput
        };
    }

    private void Move()
    {
        var targetPosition = rigidbody.position;
        var targetY = rigidbody.position.y + paddleData.speed * Time.fixedDeltaTime * verticalInput;
        targetPosition.y = Mathf.Clamp(targetY, paddleData.bounds.Lower, paddleData.bounds.Upper);
        
        rigidbody.MovePosition(targetPosition);
    }
}
