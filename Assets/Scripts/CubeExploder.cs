using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _defaultExplosionForce;
    [SerializeField] private float _defaultExplosionRadius;

    public void ExplodeWithEffect(Cube clickedCube)
    {
        Instantiate(_explosionEffect, clickedCube.transform.position, Quaternion.identity);
        
        Explode(GetCubesToExplode(clickedCube.transform.position), clickedCube);
    }
    
    public void Explode(List<Rigidbody> cubes, Cube clickedCube)
    {
        foreach (var cube in cubes)
        {
            cube.AddExplosionForce(_defaultExplosionForce / clickedCube.transform.localScale.x, clickedCube.transform.position, _defaultExplosionRadius / clickedCube.transform.localScale.x);
        }
        
        Destroy(clickedCube.gameObject);
    }

    private List<Rigidbody> GetCubesToExplode(Vector3 clickedPosition)
    {
        List<Rigidbody> targets = new List<Rigidbody>();
        
        Collider[] hits = Physics.OverlapSphere(clickedPosition, _defaultExplosionRadius);

        foreach (Collider hit in hits)
        {
            targets.Add(hit.gameObject.GetComponent<Rigidbody>());
        }

        return targets;
    }
}