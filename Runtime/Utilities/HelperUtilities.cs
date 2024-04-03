using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    /// <summary>
    /// Utility class providing helpful methods for common operations such as retrieving the mouse's world position, calculating direction vectors, and
    /// determining aim direction based on an angle in degrees.
    /// </summary>
    /// <remarks>
    /// The class includes a method to get the mouse's world position, ensuring it stays within screen bounds, a method for calculating normalized direction
    /// vectors from one position to another, and a method to derive an AimDirection enum value from an angle in degrees.
    /// </remarks>
    public static class HelperUtilities
    {
        private static Camera mainCam;
        
        /// <summary>
        /// Retrieves the world position of the mouse cursor.
        /// </summary>
        /// <returns>The world position of the mouse cursor as a Vector3.</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            if (mainCam == null) mainCam = Camera.main;
            Vector3 mouseScreenPos = Input.mousePosition;
            
            mouseScreenPos.x = Mathf.Clamp(mouseScreenPos.x, 0f, Screen.width);
            mouseScreenPos.y = Mathf.Clamp(mouseScreenPos.y, 0f, Screen.height);
            
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0;
            
            return mouseWorldPos;
        }
        
        /// <summary>
        /// Calculates and returns the normalized direction vector from the current position to the target position.
        /// </summary>
        /// <param name="currentPos">The current position vector.</param>
        /// <param name="targetPos">The target position vector.</param>
        public static Vector3 GetDirection(Vector3 currentPos, Vector3 targetPos)
        {
            return (targetPos - currentPos).normalized;
        }
    }
}