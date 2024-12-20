using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle.Input
{
    public class BattleInputWrapper : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        private const float Threshold = 0.1f;

        public bool WasPressedThisFrame(BattleInputButton battleInputButton)
        {
            return playerInput.actions[battleInputButton.ToString()].WasPressedThisFrame();
        }

        public Vector2Int GetDirection()
        {
            var origin = playerInput.actions["Move"].ReadValue<Vector2>();
            var dir = new Vector2Int();
            dir.x = origin.x switch
            {
                > Threshold => 1,
                < -Threshold => -1,
                _ => dir.x
            };
            dir.y = origin.y switch
            {
                > Threshold => 1,
                < -Threshold => -1,
                _ => dir.y
            };
            return dir;
        }
    }
}