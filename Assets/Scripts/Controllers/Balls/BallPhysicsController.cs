using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;
using Signals;

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
        private PlayerData _data;
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
                transform.parent = other.transform;
                rig.constraints = RigidbodyConstraints.None;
                BallSignals.Instance.onBallInTheCup?.Invoke();

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
    }
}