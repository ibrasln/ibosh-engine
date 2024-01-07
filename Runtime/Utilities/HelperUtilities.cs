using IboshEngine.Runtime.Enums;

namespace IboshEngine.Runtime.Utilities
{
    public static class HelperUtilities
    {
        /// <summary>
        /// Get AimDirection enum value from the passed in angleDegrees
        /// </summary>
        public static AimDirection GetAimDirection(float angleDegrees)
        {
            AimDirection aimDirection;
            switch (angleDegrees)
            {
                case > 67.5f and <= 112.5f:
                    aimDirection = AimDirection.Up;
                    break;
                case >= 22.5f and <= 67.5f:
                    aimDirection = AimDirection.UpRight;
                    break;
                case >= 0f and < 22.5f:
                case > -22.5f and <= 0f:
                    aimDirection = AimDirection.Right;
                    break;
                case >= -67.5f and <= -22.5f:
                    aimDirection = AimDirection.DownRight;
                    break;
                case > -112.5f and < -67.5f:
                    aimDirection = AimDirection.Down;
                    break;
                case >= -157.5f and <= -112.5f:
                    aimDirection = AimDirection.DownLeft;
                    break;
                case > 157.5f and <= 180f:
                case >= -180 and < -157.5f:
                    aimDirection = AimDirection.Left;
                    break;
                case >= 112.5f and <= 157.5f:
                    aimDirection = AimDirection.UpLeft;
                    break;
                default:
                    aimDirection = AimDirection.Right;
                    break;
            }

            return aimDirection;
        }
    }
}