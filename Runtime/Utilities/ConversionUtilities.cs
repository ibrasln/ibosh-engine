using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    public static class ConversionUtilities
    {
        public static float LinearToDecibels(float linear)
        {
            float linearScale = 20f;
            return Mathf.Log10(linear / linearScale) * 20f;
        }
    }
}