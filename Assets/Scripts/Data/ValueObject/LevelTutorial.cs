using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class TutorialData
    {
        public List<LevelTutorial> LevelTutorialList;
    }

    [Serializable]
    public class LevelTutorial
    {
        public List<Vector3> StartPos;
        public List<Vector3> EndPos;
    }
}