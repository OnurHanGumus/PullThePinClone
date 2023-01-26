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
        private Material _material;
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
            if (manager.IsColored)
            {
                Object[] Materials = Resources.LoadAll("Materials");
                int materialId = Random.Range(0, Materials.Length - 1);

                _material = Resources.Load<Material>("Materials/"+materialId);
                _meshRenderer.material = _material;
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