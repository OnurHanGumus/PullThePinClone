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
    public class BorderPhysicsController : MonoBehaviour
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
                StartCoroutine(FailWithDelay(1));
            }
        }
        private IEnumerator FailWithDelay(int value)
        {
            yield return new WaitForSeconds(value);
            UISignals.Instance.onSetTip?.Invoke(_tipData.TipList[2]);
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
            _isTriggered = false;
        }
    }
}