using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    /// <summary>
    /// Utility class providing methods for converting linear volume scales to decibels and extracting angles in degrees from direction vectors.
    /// </summary>
    /// <remarks>
    /// The class includes methods to convert a linear volume scale to decibels, allowing for audio-related calculations, and to derive the angle
    /// in degrees from a direction vector in 3D space.
    /// </remarks>
    public static class ConversionUtilities
    {
        /// <summary>
        /// Convert the linear volume scale to decibels
        /// </summary>
        /// /// <param name="linear">The linear volume scale to be converted.</param>
        /// <returns>The corresponding volume in decibels.</returns>
        public static float LinearToDecibels(float linear)
        {
            float linearScale = 20f;
            return Mathf.Log10(linear / linearScale) * 20f;
        }
        
        /// <summary>
        /// Get angle in degrees from a direction vector
        /// </summary>
        /// /// <param name="vector">The direction vector.</param>
        /// <returns>The angle in degrees from the provided direction vector.</returns>
        public static float VectorToAngle(Vector3 vector)
        {
            float radians = Mathf.Atan2(vector.y, vector.x);
            float degrees = radians * Mathf.Rad2Deg;

            return degrees;
        }

        /// <summary>
        /// Get direction vector from an angle in degrees
        /// </summary>
        /// /// <param name="angle">The angle.</param>
        /// <returns>The vector from the provided angle in degrees.</returns>
        public static Vector3 AngleToVector(float angle)
        {
            return new(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0f);
        }
    }
}