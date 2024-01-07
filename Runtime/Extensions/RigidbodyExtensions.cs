using UnityEngine;

namespace IboshEngine.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for the Rigidbody and Rigidbody2D components in Unity, providing additional functionality for setting velocities along different axes.
    /// </summary>
    /// <remarks>
    /// The class includes extension methods for both Rigidbody and Rigidbody2D, offering convenient ways to set velocities in 2D and 3D space.
    /// Methods are provided for setting the overall velocity as well as individual components along the X, Y, and Z axes.
    /// </remarks>
    public static class RigidbodyExtensions
    {
        #region Rigidbody2D
        public static void SetVelocity(this Rigidbody2D rigidbody, Vector2 velocity)
        {
            rigidbody.velocity = velocity;
        }
        
        public static void SetVelocityX(this Rigidbody2D rigidbody, float xVelocity)
        {
            rigidbody.velocity = new(xVelocity, rigidbody.velocity.y);
        }
        
        public static void SetVelocityY(this Rigidbody2D rigidbody, float yVelocity)
        {
            rigidbody.velocity = new(rigidbody.velocity.x, yVelocity);
        }
        #endregion

        #region Rigidbody
        public static void SetVelocity(this Rigidbody rigidbody, Vector3 velocity)
        {
            rigidbody.velocity = velocity;
        }
        
        public static void SetVelocityX(this Rigidbody rigidbody, float xVelocity)
        {
            var velocity = rigidbody.velocity;
            velocity = new(xVelocity, velocity.y, velocity.z);
            rigidbody.velocity = velocity;
        }
        
        public static void SetVelocityY(this Rigidbody rigidbody, float yVelocity)
        {
            var velocity = rigidbody.velocity;
            velocity = new(velocity.x, yVelocity, velocity.z);
            rigidbody.velocity = velocity;
        }
        
        public static void SetVelocityZ(this Rigidbody rigidbody, float zVelocity)
        {
            var velocity = rigidbody.velocity;
            velocity = new(velocity.x, velocity.y, zVelocity);
            rigidbody.velocity = velocity;
        }
        #endregion
    }
}