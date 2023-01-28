using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;
using Signals;
using Enums;

namespace Controllers
{
    public class BombPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        #endregion
        #region Private Variables
        private bool _isTriggered = false;
        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                if (_isTriggered)
                {
                    return;
                }
                _isTriggered = true;
                BombReadyToExplode();
            }
        }

        private void BombReadyToExplode()
        {
            transform.parent.DOScale(2, 0.5f).OnComplete(() => 
            {
                Explode();
            });
        }

        private void Explode()
        {
            PoolSignals.Instance.onGetObjectOnPosition?.Invoke(PoolEnums.BombParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
            transform.parent.gameObject.SetActive(false);
        }

        public void OnReleased()
        {
        }

        public void OnPlay()
        {
            


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