namespace Cariacity.game
{
    public static class Constants
    {
        public const float Hypotenuse = 1.41421356f;
        public const float HalfHypotenuse = 0.70710678118f;

        // 0.2499937841118855
        
        public const float MinCameraSpeed = 70;
        public const float MaxCameraSpeed = 10;
        public const float MinCameraZoom = 2;
        public const float MaxCameraZoom = 10;

        public const float AngleCoefficient = (MinCameraSpeed - MaxCameraSpeed) / (MinCameraZoom - MaxCameraZoom);
        public const float DisplacementCoefficient = MinCameraSpeed - (MinCameraZoom * AngleCoefficient);

        public const float BackgroundTimer = 5;

        public const int TreeProbability = 10;
        public const int GridSize = 50;
    }
}