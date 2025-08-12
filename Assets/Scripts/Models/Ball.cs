using UnityEngine;

namespace Models
{
    public class Ball
    {
        public enum Side
        {
            Left,
            Right
        }
        
        public Ball(BallData ballData)
        {
            BallData = ballData;
            Direction = Vector2.zero;
        }
        
        public Vector2 Direction { get; set; }
        public BallData BallData{ get; }
        
        public Vector2 RandomizeDirection(Side side = Side.Right)
        {
            var bounceAngleInRadians = BallData.maxBounceAngleInDegrees * Mathf.Deg2Rad;
            var angle = Random.Range(-bounceAngleInRadians, bounceAngleInRadians);
        
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            return side switch
            {
                Side.Right => direction,
                Side.Left => Vector2.Reflect(direction, Vector2.left),
                _ => Vector2.zero
            };
        }
    }
}