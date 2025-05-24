using UnityEngine;

public class CubeInteractionMediator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExploder _cubeExploder;
    [SerializeField] private InputController _inputController;

    private void OnEnable()
    {
        _inputController.CubeClicked += HandleCubeClick;
    }

    private void OnDisable()
    {
        _inputController.CubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
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