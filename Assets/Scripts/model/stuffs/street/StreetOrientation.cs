using UnityEngine;

namespace Cariacity.game
{
    public class StreetOrientation
    {
        public GameObject Model { get; set; }
        public Quaternion Rotation { get; set; }

        public StreetOrientation(GameObject model, Quaternion rotation)
        {
            Model = model;
            Rotation = rotation;
        }

        public static StreetOrientation GetOrientation(int count, bool[] directions)
        {
            switch (count)
            {
                case 1:
                    if (directions[0])
                        return new StreetOrientation(Street.EndModel, Quaternion.Euler(0, 135, 0));

                    else if (directions[1])
                        return new StreetOrientation(Street.EndModel, Quaternion.Euler(0, -135, 0));

                    else if (directions[2])
                        return new StreetOrientation(Street.EndModel, Quaternion.Euler(0, -45, 0));

                    else if (directions[3])
                        return new StreetOrientation(Street.EndModel, Quaternion.Euler(0, 45, 0));

                    break;

                case 2:
                    if (directions[0] && directions[2])
                        return new StreetOrientation(Street.LineModel, Quaternion.Euler(0, -45, 0));

                    else if (directions[1] && directions[3])
                        return new StreetOrientation(Street.LineModel, Quaternion.Euler(0, 45, 0));

                    else if (directions[0] && directions[1])
                        return new StreetOrientation(Street.CornerModel, Quaternion.Euler(0, -45, 0));

                    else if (directions[0] && directions[3])
                        return new StreetOrientation(Street.CornerModel, Quaternion.Euler(0, -135, 0));

                    else if (directions[1] && directions[2])
                        return new StreetOrientation(Street.CornerModel, Quaternion.Euler(0, 45, 0));

                    else if (directions[2] && directions[3])
                        return new StreetOrientation(Street.CornerModel, Quaternion.Euler(0, 135, 0));

                    break;

                case 3:
                    if (directions[0] && directions[1] && directions[2])
                        return new StreetOrientation(Street.TModel, Quaternion.Euler(0, -45, 0));

                    else if (directions[0] && directions[2] && directions[3])
                        return new StreetOrientation(Street.TModel, Quaternion.Euler(0, 135, 0));

                    else if (directions[1] && directions[2] && directions[3])
                        return new StreetOrientation(Street.TModel, Quaternion.Euler(0, 45, 0));

                    else if (directions[0] && directions[1] && directions[3])
                        return new StreetOrientation(Street.TModel, Quaternion.Euler(0, -135, 0));

                    break;

                case 4:
                    return new StreetOrientation(Street.CrossingModel, Quaternion.Euler(0, 45, 0));
            }

            return new StreetOrientation(Street.LineModel, Quaternion.Euler(0, 45, 0));
        }
    }
}
