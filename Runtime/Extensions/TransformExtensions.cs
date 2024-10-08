using UnityEngine;

namespace IboshEngine.Runtime.Extensions
{
    /// <summary>
    /// A collection of extension methods for the Transform component in Unity, providing convenient functions for manipulating the position, rotation, and scale of GameObjects.
    /// </summary>
    /// <remarks>
    /// These extensions include methods to translate along specific axes, set positions and scales, reset positions, scales, and transforms, and apply rotations around
    /// the X, Y, and Z axes.
    /// </remarks>
    public static class TransformExtensions
    {
        /// <summary>
        /// Extension method to translate the position of the object along the X-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="distance">The distance to move along the X-axis.</param>
        public static void TranslateX(this Transform transform, float distance)
        {
            transform.Translate(Vector3.right * distance);
        }

        /// <summary>
        /// Extension method to translate the position of the object along the Y-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="distance">The distance to move along the Y-axis.</param>
        public static void TranslateY(this Transform transform, float distance)
        {
            transform.Translate(Vector3.up * distance);
        }
        
        /// <summary>
        /// Extension method to translate the position of the object along the Z-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="distance">The distance to move along the Z-axis.</param>
        public static void TranslateZ(this Transform transform, float distance)
        {
            transform.Translate(Vector3.forward * distance);
        }

        /// <summary>
        /// Extension method to set the position of the object using a specified Vector3.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="newPosition">The new position to set for the object.</param>
        public static void SetPosition(this Transform transform, Vector3 newPosition)
        {
            transform.position = newPosition;
        }
        
        /// <summary>
        /// Extension method to set the X-coordinate of the object's position.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="newPosition">The new X-coordinate to set for the object's position.</param>
        public static void SetPositionX(this Transform transform, float newPosition)
        {
            var position = transform.position;
            position = new Vector3(newPosition, position.y, position.z);
            transform.position = position;
        }
        
        /// <summary>
        /// Extension method to set the Y-coordinate of the object's position.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="newPosition">The new Y-coordinate to set for the object's position.</param>
        public static void SetPositionY(this Transform transform, float newPosition)
        {
            var position = transform.position;
            position = new(position.x, newPosition, position.z);
            transform.position = position;
        }
        
        /// <summary>
        /// Extension method to set the Z-coordinate of the object's position.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="newPosition">The new Z-coordinate to set for the object's position.</param>
        public static void SetPositionZ(this Transform transform, float newPosition)
        {
            var position = transform.position;
            position = new(position.x, position.y, newPosition);
            transform.position = position;
        }

        /// <summary>
        /// Extension method to reset the position of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        public static void ResetPosition(this Transform transform)
        {
            transform.position = Vector3.zero;
        }
        
        /// <summary>
        /// Extension method to set the scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="scale">The new scale value to set for the object.</param>
        public static void SetScale(this Transform transform, Vector3 scale)
        {
            transform.localScale = scale;
        }
        
        /// <summary>
        /// Extension method to set the X scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="scale">The new X scale value to set for the object.</param>
        public static void SetScaleX(this Transform transform, float scale)
        {
            var localScale = transform.localScale;
            localScale = new(scale, localScale.y, localScale.z);
            transform.localScale = localScale;
        }
        
        /// <summary>
        /// Extension method to set the Y scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="scale">The new Y scale value to set for the object.</param>
        public static void SetScaleY(this Transform transform, float scale)
        {
            var localScale = transform.localScale;
            localScale = new(localScale.x, scale, localScale.z);
            transform.localScale = localScale;
        }
        
        /// <summary>
        /// Extension method to set the Z scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="scale">The new Z scale value to set for the object.</param>
        public static void SetScaleZ(this Transform transform, float scale)
        {
            var localScale = transform.localScale;
            localScale = new(localScale.x, localScale.y, scale);
            transform.localScale = localScale;
        }

        /// <summary>
        /// Extension method to reset the scale of the object to (1, 1, 1).
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        public static void ResetScale(this Transform transform)
        {
            transform.localScale = Vector3.one;
        }
        
        /// <summary>
        /// Extension method to rotate the object on the X-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateX(this Transform transform, float angle)
        {
            transform.rotation = Quaternion.Euler(angle, 0f, 0f);
        }

        /// <summary>
        /// Extension method to rotate the object on the Y-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateY(this Transform transform, float angle)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        /// <summary>
        /// Extension method to rotate the object on the Z-axis.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateZ(this Transform transform, float angle)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        
        /// <summary>
        /// Extension method to rotate the object on the X-axis locally.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateLocalX(this Transform transform, float angle)
        {
            transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
        }

        /// <summary>
        /// Extension method to rotate the object on the Y-axis locally.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateLocalY(this Transform transform, float angle)
        {
            transform.localRotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        /// <summary>
        /// Extension method to rotate the object on the Z-axis locally.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        /// <param name="angle">The angle of rotation in degrees.</param>>
        public static void RotateLocalZ(this Transform transform, float angle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
        
        /// <summary>
        /// Extension method to reset the position, rotation, and scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        public static void ResetTransform(this Transform transform)
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0, 0, 0));
            transform.localScale = Vector3.one;
        }
        
        /// <summary>
        /// Extension method to reset the localPosition, localRotation, and scale of the object.
        /// </summary>
        /// <param name="transform">The Transform component of the object.</param>
        public static void ResetLocalTransform(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = Vector3.one;
        }
    }
}
