using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button ExitButton;
    public Button MainButton;
    public GameObject ExitBackGround;
    public bool _IsOpened = false;

    public void OnClickExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
			Application.Quit();
        #endif
    }

    public void OnClickMainButton()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }

    public void OnEscPress(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _IsOpened = !_IsOpened;
            ExitBackGround.SetActive(_IsOpened);

            if (_IsOpened == false)
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (_IsOpened == true)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
