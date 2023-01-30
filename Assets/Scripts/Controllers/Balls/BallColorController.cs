using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class BallColorController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private BallManager manager;

        #endregion
        #region Private Variables
        private MeshRenderer _meshRenderer;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            
        }
        private void Start()
        {
            ChangeColor();
        }
        public void ChangeColor()
        {
            if (manager.IsColored)
            {
                int materialId = Random.Range(0, manager.Data.Colors.Count - 1);
                _meshRenderer.material.color = manager.Data.Colors[materialId];
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