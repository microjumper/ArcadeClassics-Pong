using UnityEngine;

public class AIController : MonoBehaviour, IController
{
    [SerializeField]
    private GameObject ball;
    
    [SerializeField]
    private float deadZone = 0.15f;
    
    public float GetVerticalInput()
    {
        var difference = ball.transform.position.y - transform.position.y;
        
        var direction = 0f;
        
        if (Mathf.Abs(difference) > deadZone)
        {
            direction = Mathf.Sign(difference);
        }

        return direction;
    }
}
