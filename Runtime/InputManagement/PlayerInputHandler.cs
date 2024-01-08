using UnityEngine;
using UnityEngine.InputSystem;

namespace IboshEngine.Runtime.InputManagement
{
    /// <summary>
    /// Handles player input for movement using Unity's Input System.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        /// <summary>
        /// Gets the raw movement input vector.
        /// </summary>
        public Vector2 MovementInput { get; private set; }

        /// <summary>
        /// Gets the rounded X value of the movement input.
        /// </summary>
        public float XInput { get; private set; }

        /// <summary>
        /// Gets the rounded Y value of the movement input.
        /// </summary>
        public float YInput { get; private set; }

        /// <summary>
        /// Called by the Input System to handle movement input.
        /// </summary>
        /// <param name="context">The InputAction.CallbackContext containing input data.</param>
        public void OnMove(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            XInput = Mathf.RoundToInt(MovementInput.normalized.x);
            YInput = Mathf.RoundToInt(MovementInput.normalized.y);
        }
    }
}
