using System;
using System.Collections.Generic;

namespace Cariacity.game
{
    [Serializable]
    public struct SerializableCity
    {
        public int Money;
        public List<SerializableCell> Cells;
    }

    public static class SerializaCity
    {
        public static SerializableCity GetSave()
        {
            var city = new SerializableCity { Money = 10, Cells = new List<SerializableCell>() };
            var mat = Common.Matrix;

            for (int i = 0; i < Constants.GridSize; i++)
                for (int j = 0; j < Constants.GridSize; j++)
                    if (mat[i, j].obj != null)                  // need to apply to all cells that have status diferent  of zero
                        city.Cells.Add(new SerializableCell
                        {
                            I = i,
                            J = j,
                            Type = mat[i, j].type,
                            Status = mat[i, j].status,
                            Rotation = mat[i, j].obj.transform.rotation
                        });

            return city;
        }

        public static void OpenSave(SerializableCity city)
        {
            var mat = Common.Matrix;

            foreach (var cell in city.Cells)
            {
                var c = mat[cell.I, cell.J];

                c.type = cell.Type;
                c.status = cell.Status;
                c.obj = GameController.InitObj(GameModel.Get(cell.Type), c.center, cell.Rotation);
            }
        }
    }
}
