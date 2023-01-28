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
    public class BallManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private BallColorController colorController;
        [SerializeField] private GameObject physicGameObject;
        [SerializeField] private bool isColored;

        #endregion

        #region Private Variables
        private PlayerData _data;
        private BallMovementController _movementController;

        #endregion
        #region Properties
        

        public bool IsColored
        {
            get { return isColored; }
            set { 
                    if (!isColored)
                    {
                        isColored = value;
                        colorController.ChangeColor();
                    }
                }
        }

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
            _movementController = GetComponent<BallMovementController>();
  
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

        private void OnPlay()
        {
            BallSignals.Instance.onIncreaseBallCount?.Invoke();
            BallSignals.Instance.onAddToLooseCheck?.Invoke(_movementController);

        }
        private void OnResetLevel()
        {

        }
    }
}