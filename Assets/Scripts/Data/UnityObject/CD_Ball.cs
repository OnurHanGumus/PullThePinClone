using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Ball", menuName = "Picker3D/CD_Ball", order = 0)]
    public class CD_Ball : ScriptableObject
    {
        public BallData Data;
    }
}