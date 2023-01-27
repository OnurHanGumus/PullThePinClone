using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }

}
