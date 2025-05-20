using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnEnable()
    {
        _cubeSpawner.CubeClickedWithCubesSpawn += Explode;
        _cubeSpawner.CubeClickedWithoutSpawn += ExplodeWithEffect;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeClickedWithCubesSpawn -= Explode;
        _cubeSpawner.CubeClickedWithoutSpawn += ExplodeWithEffect;
    }

    private void ExplodeWithEffect(Cube clickedCube)
    {
        Instantiate(_explosionEffect, clickedCube.transform.position, Quaternion.identity);
        
        Explode(GetCubesToExplode(clickedCube.transform.position), clickedCube);
    }
    
    private void Explode(List<Rigidbody> cubes, Cube clickedCube)
    {
        foreach (var cube in cubes)
        {
            cube.AddExplosionForce(_explosionForce / clickedCube.transform.localScale.x, clickedCube.transform.position, _explosionRadius / clickedCube.transform.localScale.x);
        }
        
        Destroy(clickedCube.gameObject);
    }

    private List<Rigidbody> GetCubesToExplode(Vector3 clickedPosition)
    {
        List<Rigidbody> targets = new List<Rigidbody>();
        
        Collider[] hits = Physics.OverlapSphere(clickedPosition, _explosionRadius);

        foreach (Collider hit in hits)
        {
            targets.Add(hit.gameObject.GetComponent<Rigidbody>());
        }

        return targets;
    }
}