using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Signals;

public class CupTextController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    #endregion

    #region Serialized Variables
    [SerializeField] private TextMeshPro percentageText;
    #endregion

    #region Private Variables
    #endregion

    #endregion
    public void UpdateText(int newValue)
    {
        percentageText.text = newValue.ToString() + "%";
        if (newValue.Equals(100))
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            PoolSignals.Instance.onGetObjectOnPosition?.Invoke(Enums.PoolEnums.ConfettiParticle, transform.position);
            AudioSignals.Instance.onPlaySound?.Invoke(Enums.SoundEnums.Win);
        }
    }

}
