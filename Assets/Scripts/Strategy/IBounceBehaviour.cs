using Models;
using UnityEngine;

namespace Strategy
{
    public interface IBounceBehaviour
    {
        void Bounce(Ball ball, Collision2D collision);
    }
}