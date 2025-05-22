using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    
    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
