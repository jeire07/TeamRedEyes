using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Defense : MonoBehaviour
{

    public void OnDefense(InputAction.CallbackContext context)
    {
        // Defense �׼�
        if (context.performed)
        {
            Debug.Log("Defense!");
        }
    }
}
