using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle.Test
{
    public class PlayerTest : NetworkBehaviour
    {
        private Rigidbody2D _rb;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            _rb.linearVelocity = _playerInput.actions["Move"].ReadValue<Vector2>()*3;
        }
    }
}