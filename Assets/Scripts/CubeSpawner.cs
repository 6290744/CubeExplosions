using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public List<Rigidbody> SpawnCubes(Cube clickedCube)
    {
        int _minimalCubesCount = 2;
        int _maximalCubesCount = 6;
        int cubesCount = Random.Range(_minimalCubesCount, _maximalCubesCount + 1);

        List<Rigidbody> spawnedCubes = new List<Rigidbody>();
        for (int i = 0;
             i < cubesCount;
             i++)
        {
            Cube spawnedCube = Instantiate(_cubePrefab);

            ConfigureCubeTransform(spawnedCube, clickedCube);

            ConfigureCubeColor(spawnedCube);

            spawnedCubes.Add(spawnedCube.Rigidbody);
        }

        return spawnedCubes;
    }

    private void ConfigureCubeTransform(Cube newCube, Cube clickedCube)
    {
        float _minimalAngleOffset = 0f;
        float _maximalAngleOffset = 360f;
        int _decreaseScaleFactor = 2;

        float angleOffset = Random.Range(_minimalAngleOffset, _maximalAngleOffset);

        newCube.transform.localScale = clickedCube.transform.localScale / _decreaseScaleFactor;
        newCube.transform.position = clickedCube.transform.position;
        newCube.transform.rotation = Quaternion.Euler(angleOffset, angleOffset, angleOffset);
    }

    private void ConfigureCubeColor(Cube newCube)
    {
        if (newCube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Random.ColorHSV();
        }
        else
        {
            throw new NullReferenceException("Doesn't have a renderer");
        }
    }
}