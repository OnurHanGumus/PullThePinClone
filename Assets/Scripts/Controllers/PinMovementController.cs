using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class PinMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        #endregion
        #region Private Variables
        private PinManager _manager;
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
            _manager = GetComponent<PinManager>();
            //_data = _manager.GetData();
        }





        private void Move()
        {
            transform.DOMove(transform.position + (transform.right * 10), 1f);
        }

        public void OnClicked()
        {
            Move();
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