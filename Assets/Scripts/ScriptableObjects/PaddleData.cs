using UnityEngine;

[CreateAssetMenu(fileName = "new PaddleData", menuName = "ScriptableObjects/PaddleData")]
public class PaddleData : ScriptableObject
{
    public Bound Bounds = new(4, -4); 
    public float Speed = 10f;
}
