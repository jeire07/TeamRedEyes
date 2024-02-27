using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public enum CanvasType
{
    Load = 0,
    Start,
    Option,
    Combined = 10,
    NotFrequent,
    Frequent,
    Null = -1
}

public enum PanelType
{
    Stat = 0,
    Inventory,
    Equip,
    Quest,
    Option,
    Save,
    Craft,
    Repair,
    Rest = 10,
    Dialog = 11,
    Null = -1
}

public class UIManager : Singleton<UIManager>
{
    private string _sceneName;
    [SerializeField] private Transform CanvasParent;

    #region test
    public GameObject FrequentUI;
    public GameObject NotFrequentUI;

    public GameObject[] Panels;
    #endregion

    public Dictionary<CanvasType, GameObject> UIDict { get; private set; } = new();
    public Dictionary<PanelType, GameObject> PanelDict { get; private set; } = new();

    public PanelType CurrentPanel { get; private set; }
    public CanvasType CurrentUI { get; private set; }

    private Animator _anim;
    private PlayerController _controller;

    private void Awake()
    {
        //_sceneName = SceneManager.GetActiveScene().name;

        //if (_sceneName == "StartScene")
        //{
        //    LoadCanvas(CanvasType.Load);
        //}
        //else// if(_sceneName == "MainScene")
        //{
        //    LoadCanvas(CanvasType.Combined);
        //}
    }

    private void Start()
    {
        _anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        UIDict.Add(CanvasType.Frequent, FrequentUI);
        UIDict.Add(CanvasType.NotFrequent, NotFrequentUI);

        PanelDict.Add(PanelType.Stat, Panels[0]);
        PanelDict.Add(PanelType.Inventory, Panels[1]);
        PanelDict.Add(PanelType.Rest, Panels[2]);
        PanelDict.Add(PanelType.Dialog, Panels[3]);

        //if (_sceneName == "StartScene")
        //{
        //    ChangeCanvasInStartScene(CanvasType.Start);
        //}
        //else if (_sceneName == "MainScene" || _sceneName == "TutorialScene")
        //{
        //    HidePanel(PanelType.Rest);
        //    HidePanel(PanelType.Dialog);
        //    HideCanvas(CanvasType.Combined, PanelType.Stat);
        //}

        _controller = GameManager.Instance.PlayerCharacter.GetComponent<PlayerController>();
        //_controller.OnToggleCanvasEvent.AddListener((CanvasType uiType) => ToggleCanvas(uiType));
    }

    public void LoadCanvas(CanvasType canvasName)
    {
        while(Enum.IsDefined(typeof(CanvasType), canvasName))
        {
            GameObject canvasPrefab = Resources.Load<GameObject>($"Prefabs/UI/Canvas/{Enum.GetName(typeof(CanvasType), canvasName)}Canvas");
            GameObject instance = Instantiate(canvasPrefab, CanvasParent);
            UIDict.Add(canvasName, instance);

            SetPanel(canvasName);

            canvasName++;
        }
    }

    public void SetPanel(CanvasType canvasName)
    {
        Transform canvas = UIDict[canvasName].GetComponent<Transform>();

        Transform panelParent = canvas.Find("Panels");

        if (panelParent != null)
        {
            for (int i = 0; i < panelParent.childCount; i++)
            {
                GameObject panel = panelParent.GetChild(i).gameObject;
                PanelDict.Add((PanelType)(i + ((int)canvasName - 10) * 10), panel);
                panel.SetActive(false);
            }
        }
    }

    public void ShowCanvas(CanvasType uiType)
    {
        UIDict[uiType].SetActive(true);
    }

    public void HideCanvas(CanvasType uiType, PanelType panelType)
    {
        HidePanel(panelType);

        UIDict[uiType].SetActive(false);
        CurrentUI = CanvasType.Null;
    }

    public void ToggleCanvas(CanvasType uiType)
    {
        if(GetIsOpened(uiType))
        {
            HideCanvas(CurrentUI, CurrentPanel);
            Debug.Log("OnCanvas");
        }
        else
        {
            ShowCanvas(CurrentUI);
            Debug.Log("OffCanvas");
        }
    }

    public bool GetIsOpened(CanvasType uiType)
    {
        return UIDict[uiType].activeSelf;
    }

    public bool GetIsOpened(PanelType uiType)
    {
        return PanelDict[uiType].activeSelf;
    }

    public void ChangeCanvasInStartScene(CanvasType uiType)
    {
        if (CurrentUI == CanvasType.Load)
            _anim.SetFloat("Animate", 0);
        else if (CurrentUI == CanvasType.Start && uiType == CanvasType.Load)
            _anim.SetFloat("Animate", 1);
        else if (CurrentUI == CanvasType.Start && uiType == CanvasType.Option)
            _anim.SetFloat("Animate", 2);
        else // (_currentUI == CanvasType.Option)
            _anim.SetFloat("Animate", 3);
        CurrentUI = uiType;
    }

    public void ChangePanel(PanelType uiType)
    {
        PanelDict[CurrentPanel].SetActive(false);

        ShowPanel(uiType);
    }

    public void ShowPanel(PanelType uiType)
    {
        PanelDict[uiType].SetActive(true);
        CurrentPanel = uiType;
    }

    public void HidePanel(PanelType uiType)
    {
        PanelDict[uiType].SetActive(false);
        CurrentPanel = PanelType.Null;
    }

    public void ToggleStatPanel()
    {
        if (PanelDict[PanelType.Stat].activeInHierarchy)
        {
            HidePanel(PanelType.Stat);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            ShowPanel(PanelType.Stat);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
