using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private ColorGenerator _colorGenerator;
    [SerializeField] private Cube _cubePrefab;

    private int _minimalCubesCount = 2;
    private int _maximalCubesCount = 6;
    private float _minimalAngleOffset = 0f;
    private float _maximalAngleOffset = 360f;
    private float _splittingChancePercent = 100;
    private int _decreaseSplitChanceFactor = 2;
    private int _decreaseScaleFactor = 2;

    public event Action<List<Rigidbody>, Cube> CubeClickedWithCubesSpawn;
    public event Action<Cube> CubeClickedWithoutSpawn;
    
    private void OnEnable()
    {
        _inputController.CubeClicked += CreateCubes;
    }

    private void OnDisable()
    {
        _inputController.CubeClicked -= CreateCubes;
    }

    private void CreateCubes(Cube clickedCube)
    {
        if (Random.Range(0f, 100f) < _splittingChancePercent)
        {
            DecreaseSplitChance();
            
            SpawnCubes(clickedCube);
        }
        else
        {
            CubeClickedWithoutSpawn?.Invoke(clickedCube);
        }
    }

    private void DecreaseSplitChance()
    {
        _splittingChancePercent /= _decreaseSplitChanceFactor;
    }

    private void SpawnCubes(Cube clickedCube)
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
        
        CubeClickedWithCubesSpawn?.Invoke(spawnedCubes, clickedCube);
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
            newCube.GetComponent<Renderer>().material.color = _colorGenerator.GetRandomColor();
        }
    }
}