using UnityEngine;

abstract public class BaseUI : MonoBehaviour
{
    bool _isActive = false;

    virtual protected void Awake()
    {
        this.gameObject.SetActive(false);
        _isActive = false;
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