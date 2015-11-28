using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(BrickPlayer2D))]
    public class BrickControl : MonoBehaviour
    {
        private BrickPlayer2D character;
        private bool jump;

        private void Awake()
        {
            character = GetComponent<BrickPlayer2D>();
            if (character.Equals(null))
                Debug.Log("Game Object Not Created");
        }

        private void Update()
        {
            if (!jump)
                // Read the jump input in Update so button presses aren't missed.
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            // bool crouch = Input.GetKey(KeyCode.LeftControl); No crouching!
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(1, false, jump);
            jump = false;
        }
    }
}