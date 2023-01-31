using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Data.UnityObject;
using DG.Tweening;

public class FailPanelController : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    #endregion
    #region SerializeField Variables
    [SerializeField] private TextMeshProUGUI tipText;
    #endregion
    #region Private Variables
    private int _level = 0;
    private string _tip;
    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {


    }

    public void OnLevelFailed()
    {
        _tip = UISignals.Instance.onGetTip();
        tipText.text = _tip;
    }
    public void OnRestartLevel()
    {
        tipText.text = "Fail.";
    }
}
