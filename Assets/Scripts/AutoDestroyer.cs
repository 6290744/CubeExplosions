using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    
    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
