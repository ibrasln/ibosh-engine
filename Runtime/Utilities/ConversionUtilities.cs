using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    public static class ConversionUtilities
    {
        /// <summary>
        /// Convert the linear volume scale to decibels
        /// </summary>
        public static float LinearToDecibels(float linear)
        {
            float linearScale = 20f;
            return Mathf.Log10(linear / linearScale) * 20f;
        }
        
        /// <summary>
        /// Get angle in degrees from a direction vector
        /// </summary>
        public static float VectorToAngle(Vector3 vector)
        {
            float radians = Mathf.Atan2(vector.y, vector.x);
            float degrees = radians * Mathf.Rad2Deg;

            return degrees;
        }
    }
}