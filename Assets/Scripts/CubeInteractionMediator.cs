using UnityEngine;
using UnityEngine.Serialization;

public class CubeInteractionMediator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;
    [SerializeField] private CubeClickDetector _cubeClickDetector;

    private void OnEnable()
    {
        _cubeClickDetector.Clicked += HandleClick;
    }

    private void OnDisable()
    {
        _cubeClickDetector.Clicked -= HandleClick;
    }

    private void HandleClick(Cube cube)
    {
        if (CanSplit(cube))
        {
            _cubeExploder.Explode(_cubeSpawner.SpawnCubes(cube), cube);
        }
        else
        {
            _cubeExploder.ExplodeWithEffect(cube);
        }
    }

    private bool CanSplit(Cube cube)
    {
        float maximalSplitChancePercent = 100f;
        
        return Random.Range(0, maximalSplitChancePercent) <= cube.SplittingChancePercent;
    }
}