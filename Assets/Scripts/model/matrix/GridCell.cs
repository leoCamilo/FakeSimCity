using UnityEngine;

namespace Cariacity.game
{
    public enum Status { Health, Security, Education, Recreation }

    public class GridCell
    {
        public int i;
        public int j;
        public int type;
        public float[] status = { 0, 0, 0, 0 };
        public Vector3 center;
        public GameObject obj;

        public override string ToString()
        {
            var outStr = "";

            // _out += "i: " + i + " j: " + j + '\n';
            // _out += "tag: " + (obj != null ? obj.tag : "null") + '\n';
            outStr += "Saúde: " + status[(int)Status.Health] + '\n';
            outStr += "Lazer: " + status[(int)Status.Recreation] + '\n';
            outStr += "Educação: " + status[(int)Status.Education];

            return outStr;
        }
    }
}
