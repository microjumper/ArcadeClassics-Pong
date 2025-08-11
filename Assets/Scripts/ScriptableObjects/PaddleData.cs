using UnityEngine;

[CreateAssetMenu(fileName = "new PaddleData", menuName = "ScriptableObjects/PaddleData")]
public class PaddleData : ScriptableObject
{
    public Bound bounds = new(4, -4); 
    public float speed = 10f;
}
