using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float minYBound = -4f;
    [SerializeField]
    private float maxYBound = 4;
    [SerializeField]
    private float speed = 10f;

    private new Rigidbody2D rigidbody;

    private float verticalInput = 0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        switch(context.phase)
        {
            case InputActionPhase.Performed:
                verticalInput = context.ReadValue<float>();
                break;

            case InputActionPhase.Canceled:
                verticalInput = 0f;
                break;
        }
    }

    private void Move()
    {
        Vector2 targetPosition = rigidbody.position + speed * Time.fixedDeltaTime * new Vector2(0, verticalInput);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minYBound, maxYBound);
        rigidbody.MovePosition(targetPosition);
    }
}
