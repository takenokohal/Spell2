using Battle.Domain.Interfaces.Player;
using UnityEngine;

namespace Battle.Domain.Core.Player
{
    public class PlayerBody
    {
        private readonly ICharacterBodyView _characterBodyView;

        public PlayerBody(ICharacterBodyView characterBodyView)
        {
            _characterBodyView = characterBodyView;
        }

        private bool _lookRight = true;

        public bool LookRight
        {
            get => _lookRight;
            set
            {
                _lookRight = value;
                _characterBodyView.Rotation = _lookRight;
            }
        }

        public float Rotation
        {
            get => LookRight ? 1 : -1;
            set => LookRight = value >= 0;
        }

        public Vector2 Forward => new Vector2(Rotation, 0);


        public Vector2 Position
        {
            get => _characterBodyView.Position;
            set => _characterBodyView.Position = value;
        }

        public Vector2 Velocity
        {
            get => _characterBodyView.Velocity;
            set => _characterBodyView.Velocity = value;
        }
    }
}