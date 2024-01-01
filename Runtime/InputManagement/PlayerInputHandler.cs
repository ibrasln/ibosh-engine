using UnityEngine;
using UnityEngine.InputSystem;

namespace IboshEngine.Runtime.InputManagement
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public float XInput { get; private set; }
        public float YInput { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            XInput = Mathf.RoundToInt(MovementInput.normalized.x);
            YInput = Mathf.RoundToInt(MovementInput.normalized.y);
        }
    }
}
