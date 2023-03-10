using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Keys;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public InputData Data;

        #endregion

        #region Serialized Variables

        //[SerializeField] FloatingJoystick joystick; //SimpleJoystick paketi eklenmeli


        #endregion

        #region Private Variables


        private float _currentVelocity; //ref type
        private Vector2? _mousePosition; //ref type
        private Vector3 _moveVector; //ref type
        private bool _isPlayerDead = false;

        #endregion

        #endregion


        private void Awake()
        {
            Data = GetInputData();
        }

        private InputData GetInputData() => Resources.Load<CD_Input>("Data/CD_Input").Data;


        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onEnableInput += OnEnableInput;
            InputSignals.Instance.onDisableInput += OnDisableInput;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            //PlayerSignals.Instance.onPlayerDie += OnChangePlayerLivingState;  //?l?? animasyonu s?ras?nda playeri hareket ettiremememiz i?in varlar.
            //PlayerSignals.Instance.onPlayerSpawned += OnChangePlayerLivingState;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onEnableInput -= OnEnableInput;
            InputSignals.Instance.onDisableInput -= OnDisableInput;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            //PlayerSignals.Instance.onPlayerDie -= OnChangePlayerLivingState;
            //PlayerSignals.Instance.onPlayerSpawned -= OnChangePlayerLivingState;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (_isPlayerDead)
                {
                    return;
                }
                //InputSignals.Instance.onInputDragged?.Invoke(new InputParams() //Joystick eklenince a?
                //{
                //    XValue = joystick.Horizontal,
                //    ZValue = joystick.Vertical
                //    //ClampValues = new Vector2(Data.ClampSides.x, Data.ClampSides.y)
                //});
            }

            if (Input.GetMouseButtonUp(0))
            {
                InputSignals.Instance.onInputDragged?.Invoke(new InputParams()
                {
                    XValue = 0,
                    ZValue = 0
                });
            }

        }

        private void OnEnableInput()
        {
            
        }

        private void OnDisableInput()
        {
            
        }

        private void OnPlay()
        {
            
        }

        //private bool IsPointerOverUIElement() //Joystick'i do?ru konumland?r?rsan buna gerek kalmaz
        //{
        //    var eventData = new PointerEventData(EventSystem.current);
        //    eventData.position = Input.mousePosition;
        //    var results = new List<RaycastResult>();
        //    EventSystem.current.RaycastAll(eventData, results);
        //    return results.Count > 0;
        //}

        private void OnReset()
        {
        }

        private void OnChangePlayerLivingState()
        {
            _isPlayerDead = !_isPlayerDead;
        }

    }
}