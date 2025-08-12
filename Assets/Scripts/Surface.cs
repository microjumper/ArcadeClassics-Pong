using System;
using Strategy;
using UnityEngine;

public enum SurfaceType
{
    Wall,
    Paddle
}

public class Surface : MonoBehaviour, IBounceBehaviorProvider
{
    public IBounceBehaviour BounceBehaviour { get; private set; }
    
    [SerializeField]
    private SurfaceType surfaceType;

    private void Start()
    {
        BounceBehaviour = surfaceType switch
        {
            SurfaceType.Wall => new WallBounce(),
            SurfaceType.Paddle => new PaddleBounce(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}