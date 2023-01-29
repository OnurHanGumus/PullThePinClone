using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;
using Signals;

namespace Controllers
{
    public class BallMovementController : MonoBehaviour
    {
        #region Self Variables
        #region Public Variables
        public bool IsMoving = false;
        public bool IsInTheCup = false;


        #endregion
        #region Serialized Variables


        #endregion
        #region Private Variables

        private Rigidbody _rig;
        private BallManager _manager;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _rig = GetComponent<Rigidbody>();
            _manager = GetComponent<BallManager>();
        }
        private void Update()
        {
            if (IsInTheCup)
            {
                return;
            }

            IsMoving = _rig.velocity.magnitude > 0.1f;
        }


        public void OnReleased()
        {
        }


        public void OnPlay()
        {
            _isNotStarted = false;
        }
        public void OnLevelFailed()
        {


        }
        public void OnLevelSuccess()
        {

        }
        public void OnRestartLevel()
        {

        }
    }
}