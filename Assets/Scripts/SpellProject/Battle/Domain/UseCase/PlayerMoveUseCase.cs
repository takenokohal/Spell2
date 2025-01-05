using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerMoveUseCase
    {
        private readonly PlayerBody _playerBody;
        private readonly IPlayerConstData _playerConstData;

        public PlayerMoveUseCase(PlayerBody playerBody, IPlayerConstData playerConstData)
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