using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Data.UnityObject;
using DG.Tweening;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    #endregion
    #region SerializeField Variables
    [SerializeField] private TextMeshProUGUI levelText;
    #endregion
    #region Private Variables
    private int _level = 0;
    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {


    }

    public void OnPlay()
    {
        _level = LevelSignals.Instance.onGetLevelId();
        UpdateText();
    }

    public void UpdateText()
    {
        levelText.text = "Level " + (_level + 1);
    }
    
    public void OnRestartLevel()
    {
        levelText.text = "Level " + (_level + 1);
    }
}
