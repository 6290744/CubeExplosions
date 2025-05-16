using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void OnEnable()
    {
        _inputController.CubeClicked += Destroy;
        _cubeSpawner.SpawnedCubes += ExplodeFromCenter;
    }

    private void OnDisable()
    {
        _inputController.CubeClicked -= Destroy;
        _cubeSpawner.SpawnedCubes -= ExplodeFromCenter;
    }

    private void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
    
    private void ExplodeFromCenter(List<Rigidbody> spawnedCubes, Vector3 center)
    {
        foreach (var cube in spawnedCubes)
        {
            cube.AddExplosionForce(_explosionForce, center, _explosionRadius);
        }
    }
}