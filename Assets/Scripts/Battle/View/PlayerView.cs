using Battle.Model.Player;
using UnityEngine;

namespace Battle.View
{
    public class PlayerView : MonoBehaviour, IPlayerBodyView
    {
        [SerializeField] private float rotationValue;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public Vector2 Position
        {
            get => _rigidbody2D.position;
            set => _rigidbody2D.position = value;
        }

        public Vector2 Velocity
        {
            get => _rigidbody2D.linearVelocity;
            set => _rigidbody2D.linearVelocity = value;
        }

        public bool Rotation { get; set; }
    }
}