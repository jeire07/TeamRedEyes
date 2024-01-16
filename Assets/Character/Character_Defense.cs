using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Defense : MonoBehaviour
{

    public void OnDefense(InputAction.CallbackContext context)
    {
        // Defense ¾×¼Ç
        if (context.performed)
        {
            Debug.Log("Defense!");
        }
    }
}
