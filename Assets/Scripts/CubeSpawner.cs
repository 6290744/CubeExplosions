using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _minimalCubesCount = 2;
    private int _maximalCubesCount = 6;
    private float _minimalAngleOffset = 0f;
    private float _maximalAngleOffset = 360f;
    private int _decreaseScaleFactor = 2;

    public List<Rigidbody> SpawnCubes(Cube clickedCube)
    {
        int cubesCount = Random.Range(_minimalCubesCount, _maximalCubesCount);
        
        List<Rigidbody> spawnedCubes = new List<Rigidbody>();

        for (int i = 0; i < cubesCount; i++)
        {
            Cube spawnedCube = Instantiate(_cubePrefab);
            
            ConfigureCubeTransform(spawnedCube, clickedCube);
            
            ConfigureCubeColor(spawnedCube);
            
            spawnedCubes.Add(spawnedCube.GetComponent<Rigidbody>());
        }
        
        return spawnedCubes;
    }
    
    private void ConfigureCubeTransform(Cube newCube, Cube clickedCube)
    {
        float angleOffset = Random.Range(_minimalAngleOffset, _maximalAngleOffset);
        
        newCube.transform.localScale = clickedCube.transform.localScale / _decreaseScaleFactor;
        newCube.transform.position = clickedCube.transform.position;
        newCube.transform.rotation = Quaternion.Euler(angleOffset, angleOffset, angleOffset);
    }

    private void ConfigureCubeColor(Cube newCube)
    {
        if (newCube.GetComponent<Renderer>() != null)
        {
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}