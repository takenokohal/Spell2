using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerMoveUseCase
    {
        private readonly PlayerBody _playerBody;
        private readonly IBattleConstDataProvider _battleConstDataProvider;

        public PlayerMoveUseCase(PlayerBody playerBody, IBattleConstDataProvider battleConstDataProvider)
        {
            _playerBody = playerBody;
            _battleConstDataProvider = battleConstDataProvider;
        }

        public void Move(Vector2Int inputDirection)
        {
            var dir = (Vector2)inputDirection;
            dir.Normalize();

            _playerBody.Velocity = dir * _battleConstDataProvider.GetBattleConstData().PlayerMoveSpeed;
        }
    }
}