using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private float _defaultSplittingChancePercent = 100f;
    
    public float SplittingChancePercent => 
        _defaultSplittingChancePercent * transform.localScale.x;
}