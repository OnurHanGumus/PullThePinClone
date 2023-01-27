using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CupMovementController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    #endregion

    #region Serialized Variables

    #endregion

    #region Private Variables
    #endregion

    #endregion
    public void Move(float newValue)
    {
        transform.DOMoveY(newValue, 0.1f);
    }

}
