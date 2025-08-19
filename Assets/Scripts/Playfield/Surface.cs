using System;
using BouncingBehaviors;
using UnityEngine;

namespace Playfield
{
    public enum SurfaceType
    {
        Wall,
        Paddle
    }

    public class Surface : MonoBehaviour, IBouncingBehaviorProvider
    {
        public IBounceBehavior BounceBehavior { get; private set; }
    
        [SerializeField]
        private SurfaceType surfaceType;

        private void Start()
        {
            BounceBehavior = surfaceType switch
            {
                SurfaceType.Wall => new WallBounce(),
                SurfaceType.Paddle => new PaddleBounce(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}