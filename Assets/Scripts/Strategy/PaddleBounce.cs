using Models;
using UnityEngine;

namespace Strategy
{
    public class PaddleBounce : IBounceBehaviour
    {
        public void Bounce(Ball ball, Collision2D collision)
        {
            var paddleCenter = collision.collider.bounds.center;
            var paddleExtentsY = collision.collider.bounds.extents.y;
            var contactPoint = collision.GetContact(0).point;
            
            // Calculate the hit factor (a value from -1 to 1 based on where the ball hit)
            var hitFactor = Mathf.Clamp((contactPoint.y - paddleCenter.y) / paddleExtentsY, -1, 1);

            ball.Direction = new Vector2(-Mathf.Sign(ball.Direction.x), hitFactor).normalized;
            ball.BallData.speed = Mathf.Min(ball.BallData.speed * ball.BallData.speedIncrease, ball.BallData.maxSpeed); 
        }
    }
}