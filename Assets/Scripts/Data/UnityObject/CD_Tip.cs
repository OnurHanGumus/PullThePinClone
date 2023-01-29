using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Tip", menuName = "Picker3D/CD_Tip", order = 0)]
    public class CD_Tip : ScriptableObject
    {
        public TipData Data;
    }
}