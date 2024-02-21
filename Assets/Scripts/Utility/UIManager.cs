using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public enum CanvasType
{
    Start,
    InGame,
    Dialog,
    CraftItem,
    Repair,
    Rest
}

public enum DetailType
{
    Load,
    Status,
    Inventory,
    Equipment,
    Quest,
    Option,
    CraftItem,
    Repair
}

public class UIManager : Singleton<UIManager>
{
    private Dictionary<CanvasType, GameObject> _uiDict = new();
    private Dictionary<DetailType, GameObject> _detailDict = new();
    private string _sceneName;

    private GameObject _currentDetail;
    private GameObject _currentUI;

    private void Awake()
    {
        _sceneName = SceneManager.GetActiveScene().name;

        if(_sceneName == "StartScene")
        {
            OpenCanvas(CanvasType.Start);
        }
        else if(_sceneName == "MainScene")
        {
            OpenCanvas(CanvasType.InGame);
        }
    }

    public void ChangeDetail(DetailType uiType)
    {
        if (_detailDict.ContainsKey(uiType))
        {
            _currentUI.SetActive(false);

            _currentUI = Resources.Load<GameObject>($"Prefabs/UI/{Enum.GetName(typeof(DetailType), uiType)}");
            //Addressables.LoadAssetAsync<GameObject>(uiType.ToString()).Completed += OnLoadDone;
            Instantiate(_currentUI);

            _detailDict[uiType].SetActive(true);
        }
        else
        {
            _currentUI.SetActive(false);

            _currentUI = Resources.Load<GameObject>($"Prefabs/UI/{Enum.GetName(typeof(DetailType), uiType)}");
            //Addressables.LoadAssetAsync<GameObject>(uiType.ToString()).Completed += OnLoadDone;
            Instantiate(_currentUI);
        }
    }

    public void OpenCanvas(CanvasType uiType)
    {
        if (!_uiDict.ContainsKey(uiType))
        {
            _currentUI = Resources.Load<GameObject>($"Prefabs/UI/{uiType.ToString()}");
            //Addressables.LoadAssetAsync<GameObject>(uiType.ToString()).Completed += OnLoadDone;
            Instantiate(_currentUI);
        }
        else
        {
            _uiDict[uiType].SetActive(true);
        }
    }

    public void ChangeUITab(DetailType detailType)
    {
        if (!_detailDict.ContainsKey(detailType))
        {
            _currentUI = Resources.Load<GameObject>($"Prefabs/UI/{Enum.GetName(typeof(DetailType), detailType)}");
            //Addressables.LoadAssetAsync<GameObject>(uiType.ToString()).Completed += OnLoadDone;
            Instantiate(_currentUI);
            _currentUI.transform.SetParent(_currentUI.transform);
        }
        else
        {
            _detailDict[detailType].SetActive(true);
        }
    }
}
