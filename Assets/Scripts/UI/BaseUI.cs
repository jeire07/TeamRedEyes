using UnityEngine;

abstract public class BaseUI : MonoBehaviour
{
    private bool _isActive;

    virtual public void OnEnable()
    {

    }

    virtual public void OnDisable()
    {

    }

    virtual public void Show()
    {
        this.gameObject.SetActive(true);
        _isActive = true;
    }

    virtual public void Hide()
    {
        this.gameObject.SetActive(false);
        _isActive = false;

    }

    public void Toggle()
    {
        if (_isActive)
            this.Hide();
        else
            this.Show();
    }
}