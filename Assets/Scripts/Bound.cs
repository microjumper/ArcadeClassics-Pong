using UnityEngine;

[System.Serializable]
public class Bound
{
    [SerializeField] 
    private float upper;
    [SerializeField]
    private float lower;

    public float Upper => upper;
    public float Lower => lower;

    public Bound(float upper, float lower)
    {
        this.upper = upper;
        this.lower = lower;
    }
}