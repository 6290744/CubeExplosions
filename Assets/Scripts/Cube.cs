using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _defaultSplittingChancePercent = 100f;
    
    public float SplittingChancePercent => 
        _defaultSplittingChancePercent * transform.localScale.x;
    
    public Rigidbody Rigidbody => _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>() ?? throw new MissingComponentException("Rigidbody is null.");
    }
}