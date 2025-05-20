using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    
    private RaycastHit _hit;
    private Ray _ray;
    private float _rayDistance = 100f;
    private Cube _clickedCube;
    private int _leftMouseButton = 0;
    
    public event Action<Cube> CubeClicked;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(_ray, out _hit, _rayDistance, _layerMask))
            {
                _clickedCube = _hit.collider.GetComponent<Cube>();
            
                if (_clickedCube!= null)
                {
                    CubeClicked?.Invoke(_clickedCube);
                }
            }
        }
    }
}