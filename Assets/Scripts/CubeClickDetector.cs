using System;
using UnityEngine;

public class CubeClickDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _mouseButtonId;

    private Camera _mainCamera;

    public event Action<Cube> Clicked;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnValidate()
    {
        _mouseButtonId = Mathf.Clamp(_mouseButtonId, 0, 2);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonId))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            float rayDistance = 120;

            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, _layerMask) &&
                hit.collider.TryGetComponent(out Cube clickedCube))
            {
                Clicked?.Invoke(clickedCube);
            }
        }
    }
}