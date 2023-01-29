using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;
using Signals;
using System.Collections;
using Data.UnityObject;

namespace Controllers
{
    public class BallPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private BallManager manager;
        [SerializeField] private Rigidbody rig;
        #endregion
        #region Private Variables
        private TipData _tipData;
        private Collider _collider;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _collider = GetComponent<SphereCollider>();
            _tipData = manager.GetTipData();

            if (manager.IsColored.Equals(true))
            {
                BecomeColorful();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ColorfulBall"))
            {
                if (manager.IsColored)
                {
                    return;
                }

                manager.IsColored = true;
                BecomeColorful();
            }
            else if (other.CompareTag("Cup"))
            {
                if (manager.IsColored)
                {
                    transform.parent.parent = other.transform;
                    rig.constraints = RigidbodyConstraints.None;

                    BallSignals.Instance.onBallInTheCup?.Invoke();
                }
                else
                {
                    PoolSignals.Instance.onGetObjectOnPosition?.Invoke(Enums.PoolEnums.EvaporationParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z -1));

                    BallSignals.Instance.OnColorlessBallOnCup?.Invoke();
                    rig.useGravity = false;
                    rig.isKinematic = true;
                    rig.velocity = Vector3.zero;
                    rig.angularVelocity = Vector3.zero;
                    rig.position = new Vector3(50, 20, 0);
                }
                manager.BallInTheCup();
            }
            else if (other.CompareTag("Explosion"))
            {
                rig.constraints = RigidbodyConstraints.None;
                rig.AddForce(Vector3.back * 10, ForceMode.Impulse);

                StartCoroutine(FailWithDelay(1));
            }
        }
        private void BecomeColorful()
        {
            gameObject.tag = "ColorfulBall";
            _collider.enabled = false;
            _collider.enabled = true;
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
        private IEnumerator FailWithDelay(int value)
        {
            yield return new WaitForSeconds(value);
            UISignals.Instance.onSetTip?.Invoke(_tipData.TipList[0]);

            CoreGameSignals.Instance.onLevelFailed?.Invoke();
        }
    }
}