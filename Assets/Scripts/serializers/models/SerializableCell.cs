using System;
using UnityEngine;

namespace Cariacity.game
{
    [Serializable]
    public class SerializableCell
    {
        public int I;
        public int J;
        public int Type;
        public float[] Status;
        public Quaternion Rotation;
    }
}