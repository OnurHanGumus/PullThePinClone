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
    public class PinManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables
        private PlayerData _data;
        private PinMovementController _movementController;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
            _movementController = GetComponent<PinMovementController>();
        }
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnMouseDown()
        {
            _movementController.OnClicked();
            PinSignals.Instance.onPinHasPulled?.Invoke();
            AudioSignals.Instance.onPlaySound?.Invoke(SoundEnums.PullThePin);
        }
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {

        }
    }
}