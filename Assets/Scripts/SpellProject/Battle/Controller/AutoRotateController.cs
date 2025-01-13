using System.Threading;
using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Controller
{
    public class AutoRotateController
    {
        private readonly CancellationToken _cancellationToken;
        private readonly PlayerKey _playerKey;
        private readonly AllPlayerManager _allPlayerManager;

        public static void Start(CancellationToken cancellationToken, PlayerKey playerKey,
            AllPlayerManager allPlayerManager)
        {
            var v = new AutoRotateController(cancellationToken, playerKey, allPlayerManager);
            v.AutoRotate().Forget();
        }

        private AutoRotateController(CancellationToken cancellationToken, PlayerKey playerKey,
            AllPlayerManager allPlayerManager)
        {
            _cancellationToken = cancellationToken;
            _playerKey = playerKey;
            _allPlayerManager = allPlayerManager;
        }

        private async UniTaskVoid AutoRotate()
        {
            await UniTask.WaitUntil(() => _allPlayerManager.Players.Count >= 2, cancellationToken: _cancellationToken);
            while (!_cancellationToken.IsCancellationRequested)
            {
                var ownerBody = _allPlayerManager.GetPlayer(_playerKey).PlayerBody;
                var enemyBody = _allPlayerManager.GetEnemy(_playerKey).PlayerBody;

                var rot = enemyBody.Position.x - ownerBody.Position.x;
                ownerBody.Rotation = rot;
                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, cancellationToken: _cancellationToken);
            }
        }
    }
}