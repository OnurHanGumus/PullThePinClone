using System;
using System.Collections;
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
    public class LooseLaterManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private List<BallMovementController> ballMovementControllers;

        #endregion

        #region Private Variables
        private PlayerData _data;
        private bool _isCheckStarted = false;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
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

            BallSignals.Instance.onAddToLooseCheck += OnAddLooseCheck;
            BallSignals.Instance.OnColorlessBallOnCup += OnColorlessBallOnCup;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;

            BallSignals.Instance.onAddToLooseCheck -= OnAddLooseCheck;
            BallSignals.Instance.OnColorlessBallOnCup -= OnColorlessBallOnCup;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnAddLooseCheck(BallMovementController movementController)
        {
            ballMovementControllers.Add(movementController);
        }

        private void OnColorlessBallOnCup()
        {
            if (_isCheckStarted)
            {
                return;
            }
            _isCheckStarted = true;
            StartCoroutine(CheckMoveStates());
        }

        private IEnumerator CheckMoveStates()
        {
            while (_isCheckStarted)
            {
                int indeks = 0;
                yield return new WaitForSeconds(1f);

                foreach (var i in ballMovementControllers)
                {
                    if (i == null)
                    {
                        continue;
                    }
                    if (i.IsMoving == false)
                    {
                        ++indeks;
                        if (indeks == ballMovementControllers.Count)
                        {
                            CoreGameSignals.Instance.onLevelFailed?.Invoke();
                            _isCheckStarted = false;
                        }
                    }
                }

                if (ballMovementControllers.Count == 0)
                {
                    CoreGameSignals.Instance.onLevelFailed?.Invoke();
                }
            }
        }
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {
            ballMovementControllers.Clear();
            StopAllCoroutines();
            _isCheckStarted = false;
        }
    }
}