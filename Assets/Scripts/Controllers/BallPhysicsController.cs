using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class BallPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        #endregion
        #region Private Variables
        private BallManager _manager;
        private PlayerData _data;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _manager = GetComponent<BallManager>();
            //_data = _manager.GetData();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                
            }
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