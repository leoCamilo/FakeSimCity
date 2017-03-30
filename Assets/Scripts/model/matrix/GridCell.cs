using UnityEngine;

namespace Cariacity.game
{
    public enum Status { Health, Security }

    public class GridCell
    {
        public int i;
        public int j;
        public float[] status = { 0, 0, 0 };
        public Vector3 center;
        public GameObject obj;

        public override string ToString()
        {
            string _out = "";

            _out += "i: " + i + " j: " + j + '\n';
            _out += "tag: " + (obj != null ? obj.tag : "null") + '\n';
            _out += "health: " + status[(int)Status.Health] + '\n';
            _out += "security: " + status[(int)Status.Security];

            return _out;
        }
    }
}
