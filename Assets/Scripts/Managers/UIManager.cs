using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CanvasType
{
    Load = 0,
    Start,
    Option,
    Frequent = 10,
    NotFrequent,
    Dialog,
    Rest,
    Utility
}

public enum PanelType
{
    Stat = 0,
    Inventory,
    Equip,
    Quest,
    Option,
    Save,
    Craft = 10,
    Repair = 20
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Transform CanvasGroup;
    private Dictionary<CanvasType, BaseUI> _UIDict = new();
    private Dictionary<PanelType, BaseUI> _panelDict = new();
    private string _sceneName;

    private PanelType _currentPanel;
    private CanvasType _currentUI;

    private Animator _anim;

    private void Awake()
    {
        _sceneName = SceneManager.GetActiveScene().name;

        if (_sceneName == "StartScene")
        {
            LoadCanvas(CanvasType.Load);
        }
        else if(_sceneName == "MainScene")
        {
            LoadCanvas(CanvasType.Frequent);
        }
    }

    private void Start()
    {
        _anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        if (_sceneName == "StartScene")
        {
            ChangeCanvasInStartScene(CanvasType.Start);
        }
        else if (_sceneName == "MainScene")
        {
            Show(CanvasType.Frequent);
            Show(CanvasType.NotFrequent);
        }
    }

    public void LoadCanvas(CanvasType canvasName)
    {
        while(Enum.IsDefined(typeof(CanvasType), canvasName))
        {
            GameObject canvasObj = Resources.Load<GameObject>($"Prefabs/UI/{Enum.GetName(typeof(CanvasType), canvasName)}");
            Instantiate(canvasObj, CanvasGroup);

            BaseUI panel = canvasObj.GetComponent<BaseUI>();
            _UIDict.Add(canvasName, panel);

            canvasName++;
        }
    }

    public void Show(CanvasType uiType)
    {
        _UIDict[uiType].Show();
        _currentUI = uiType;
    }

    public void Hide(CanvasType uiType)
    {
        _UIDict[uiType].Hide();
    }

    public void Toggle(CanvasType uiType)
    {
        _UIDict[uiType].Toggle();
    }

    public void ChangeCanvasInStartScene(CanvasType uiType)
    {
        _anim.SetFloat("Animate", 0);
        _currentUI = uiType;
    }

    public void ChangePanel(PanelType uiType)
    {
        _panelDict[_currentPanel].Hide();

        _panelDict[uiType].Show();
        _currentPanel = uiType;
    }
}
