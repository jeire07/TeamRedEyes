using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sight : MonoBehaviour
{
    [SerializeField]
    private float _defaultFarClipPlane = 100f;
    [SerializeField]
    private float _defaultFieldOFView = 60f;
    [SerializeField] private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    public void SetFarClipPlane(float sightRange)
    {
        if(_mainCamera != null)
        {
            _mainCamera.farClipPlane = sightRange;
        }
        else
        {
            Debug.Log("main camera not found");
        }
    }

    public void ResetCamSight()
    {
        _mainCamera.farClipPlane = _defaultFarClipPlane;
        _mainCamera.fieldOfView = _defaultFieldOFView;
    }
}
