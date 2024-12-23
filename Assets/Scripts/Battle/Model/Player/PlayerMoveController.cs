using Data.Database;
using UnityEngine;

namespace Battle.Model.Player
{
    public class PlayerMoveController
    {
        private readonly PlayerBody _playerBody;
        private readonly PlayerConstData _playerConstData;

        public PlayerMoveController(PlayerBody playerBody, PlayerConstData playerConstData)
        {
            _playerBody = playerBody;
            _playerConstData = playerConstData;
        }

        public void Move(Vector2Int inputDirection)
        {
            var dir = (Vector2)inputDirection;
            dir.Normalize();

            _playerBody.Velocity = dir * _playerConstData.MoveSpeed;

            if (inputDirection == Vector2Int.zero)
                return;

            _playerBody.Rotation = inputDirection.x;
        }
    }
}