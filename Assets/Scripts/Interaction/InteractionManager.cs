using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private TextMeshProUGUI _interactText;
    [SerializeField] private float CheckRate = 0.05f;
    [SerializeField] private float MaxDistance = 3.0f;
    [SerializeField] private LayerMask _layerMask = LayerMask.GetMask("Interactable");
    #endregion

    #region private field
    private float _lastCheckTime;

    private GameObject _curGameobject;
    private IInteractable _curInteractable;

    private Camera _camera;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastCheckTime > CheckRate)
        {
            _lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, MaxDistance, _layerMask))
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
                _curGameobject = null;
                _curInteractable = null;
                _interactText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        _interactText.gameObject.SetActive(true);
        _interactText.text = string.Format($"{_curInteractable.GetInteractText()}");
    }

    public void OnInteractInput(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started && _curInteractable != null)
        {
            _curInteractable.Interact();
            _curGameobject = null;
            _curInteractable = null;
            _interactText.gameObject.SetActive(false);
        }
    }
}
