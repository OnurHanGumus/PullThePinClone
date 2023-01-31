using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using DG.Tweening;

namespace Managers
{
    public class TutorialManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private Transform pointer;
        #endregion

        #region Private Variables
        private TutorialData _data;
        private int _levelId;
        private LevelTutorial _selectedLevelTutorial;
        private int _selectedLevelTutorialId;
        private Tween _myTween;
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

        public TutorialData GetData() => Resources.Load<CD_Tutorial>("Data/CD_Tutorial").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
            PinSignals.Instance.onPinHasPulled += OnPinHasPulled;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
            PinSignals.Instance.onPinHasPulled -= OnPinHasPulled;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            _levelId = LevelSignals.Instance.onGetLevelId();
        }
        private void OnPlay()
        {
            _levelId = LevelSignals.Instance.onGetLevelId();

            for (int i = 0; i < _data.LevelTutorialList.Count; i++)
            {
                if (_levelId == i)
                {
                    _selectedLevelTutorial = _data.LevelTutorialList[i];
                    pointer.gameObject.SetActive(true);
                    Tutorial();
                    break;
                }
            }
        }
        private void Tutorial()
        {
            if (_selectedLevelTutorialId >= _selectedLevelTutorial.StartPos.Count)
            {
                pointer.gameObject.SetActive(false);
                return;
            }
            pointer.transform.position = _selectedLevelTutorial.StartPos[_selectedLevelTutorialId];
            _myTween = pointer.DOMove(_selectedLevelTutorial.EndPos[_selectedLevelTutorialId], 1f).OnComplete(() =>
            {
                Tutorial();
            });
        }
        private void OnPinHasPulled()
        {
            if (_selectedLevelTutorial == null)
            {
                return;
            }
            _myTween.Kill();
            ++_selectedLevelTutorialId;
            Tutorial();
        }
        private void OnRestartLevel()
        {
            pointer.gameObject.SetActive(false);
            _selectedLevelTutorialId = 0;
            if (_myTween != null)
            {
                _myTween.Kill();
            }
        }
    }
}