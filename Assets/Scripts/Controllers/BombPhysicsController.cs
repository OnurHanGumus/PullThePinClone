using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;
using Signals;
using Enums;
using System.Collections;
using Data.UnityObject;

namespace Controllers
{
    public class BombPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        #endregion
        #region Private Variables
        private bool _isTriggered = false;
        private TipData _tipData;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _tipData = GetTipData();
        }
        public TipData GetTipData() => Resources.Load<CD_Tip>("Data/CD_Tip").Data;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball") || other.CompareTag("ColorfulBall"))
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
            transform.parent.position = new Vector3(50,0,0);
            StartCoroutine(FailWithDelay(1));

        }
        private IEnumerator FailWithDelay(int value)
        {
            yield return new WaitForSeconds(value);
            UISignals.Instance.onSetTip?.Invoke(_tipData.TipList[0]);
            CoreGameSignals.Instance.onLevelFailed?.Invoke();
            AudioSignals.Instance.onPlaySound?.Invoke(SoundEnums.Lose);
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