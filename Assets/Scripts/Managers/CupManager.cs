using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CupManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        public int TotalBallCount = 0;
        #endregion

        #region Serialized Variables
        [SerializeField] private CupTextController cupTextController;
        #endregion

        #region Private Variables
        private int _currentCollectedBallCount = 0;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
            BallSignals.Instance.onIncreaseBallCount += OnIncreaseTotalCarCount;
            BallSignals.Instance.onBallInTheCup += OnIncreaseBallCount;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
            BallSignals.Instance.onIncreaseBallCount -= OnIncreaseTotalCarCount;
            BallSignals.Instance.onBallInTheCup -= OnIncreaseBallCount;
        }
        private void OnIncreaseBallCount()
        {
            ++_currentCollectedBallCount;
            Debug.Log("tetiklendi");
            cupTextController.UpdateText(_currentCollectedBallCount * 100 / TotalBallCount);
        }

        private void OnIncreaseTotalCarCount()
        {
            ++TotalBallCount;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {
            TotalBallCount = 0;
        }
    }
}