using UnityEngine;

namespace Cariacity.game
{
    public struct BuildingData
    {
        public int InfuenceType { get; set; }
        public int InfluenceBound { get; set; }
        public float Value { get; set; }

        public GameObject Project { get; set; }
        public GameObject Model { get; set; }
        public Rectangle Bounds { get; set; }
    }
}
