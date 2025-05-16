using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    private float _minimalColorValue = 0f;
    private float _maximalColorValue = 1f;
    
    public Color GetRandomColor()
    {
        return new Color(
            Random.Range(_minimalColorValue, _maximalColorValue), 
            Random.Range(_minimalColorValue, _maximalColorValue), 
            Random.Range(_minimalColorValue, _maximalColorValue));
    }
}
