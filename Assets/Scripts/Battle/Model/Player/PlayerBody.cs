using UnityEngine;

namespace Battle.Model.Player
{
    public class PlayerBody
    {
        private readonly IPlayerBodyView _playerBodyView;

        public PlayerBody(IPlayerBodyView playerBodyView)
        {
            _playerBodyView = playerBodyView;
        }

        private bool _lookRight;

        public bool LookRight
        {
            get => _lookRight;
            set
            {
                _lookRight = value;
                _playerBodyView.Rotation = _lookRight;
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
            get => _playerBodyView.Position;
            set => _playerBodyView.Position = value;
        }

        public Vector2 Velocity
        {
            get => _playerBodyView.Velocity;
            set => _playerBodyView.Velocity = value;
        }
    }
}