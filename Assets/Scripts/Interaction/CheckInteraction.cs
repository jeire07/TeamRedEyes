﻿using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckInteraction : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float _checkRate = 0.05f;
    [SerializeField] private float _maxDistance = 3.0f;

    [SerializeField] private TMP_Text _interactText;
    [SerializeField] private GameObject _curGameobject;
    #endregion

    #region private field

    private Camera _camera;

    private IInteractable _curInteractable;
    private LayerMask _layerMask;
    private LayerMask _NotInteractablelayerMask;

    private float _lastCheckTime;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _layerMask = LayerMask.GetMask("Interactable", "NotInteractable");

        //Transform canvas = UIManager.Instance.UIDict[CanvasType.NotFrequent].GetComponent<Transform>();
        //_interactText = canvas.Find("InteractionText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastCheckTime > _checkRate)
        {
            _lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistance, _layerMask))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("NotInteractable"))
                {
                    _curGameobject = null;
                    _curInteractable = null;
                    _interactText.enabled = false;
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    if (hit.collider.gameObject != _curGameobject)
                    {
                        _curGameobject = hit.collider.gameObject;
                        _curInteractable = hit.collider.GetComponent<IInteractable>();
                        SetPromptText();
                    }
                }
                else
                {
                    //_curGameobject = null;
                    //_curInteractable = null;
                    //_interactText.enabled = false;
                }
            }
            else
            {
                _curGameobject = null;
                _curInteractable = null;
                _interactText.enabled = false;
            }
        }
    }

    private void SetPromptText()
    {
        _interactText.enabled = true;

        if(_curInteractable != null)
            _interactText.text = _curInteractable.GetInteractText();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && _curInteractable != null)
        {
            if (UIManager.Instance.GetIsOpened(PanelType.Rest) ||
            UIManager.Instance.GetIsOpened(PanelType.Dialog) ||
            UIManager.Instance.GetIsOpened(PanelType.Inventory))
            {
                Debug.Log($"{UIManager.Instance.GetIsOpened(PanelType.Rest)},{UIManager.Instance.GetIsOpened(PanelType.Dialog)},{UIManager.Instance.GetIsOpened(PanelType.Inventory)}");
                return;
            }

            Debug.Log("run");
            _curInteractable.Interact();
            _interactText.enabled = false;
        }
    }
}
