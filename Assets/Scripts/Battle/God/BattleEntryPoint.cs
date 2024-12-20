using Battle.God.Factory;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Battle.God
{
    public class BattleEntryPoint : SimulationBehaviour, IPlayerJoined
    {
        [Inject] private readonly PlayerFactory _playerFactory;
        [Inject] private readonly NetworkRunner _networkRunner;

        private void Start()
        {
            Init().Forget();
        }

        private async UniTaskVoid Init()
        {
            var result = await _networkRunner.StartGame(new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SceneManager = _networkRunner.GetComponent<NetworkSceneManagerDefault>()
            });

            if (result.Ok)
            {
                Debug.Log("OK!");
            }
            else
            {
                Debug.Log("Failed...");
            }
        }
        void IPlayerJoined.PlayerJoined(PlayerRef player)
        {
            Debug.Log(player.PlayerId);
            Debug.Log(_networkRunner.LocalPlayer.PlayerId);
            if (player != _networkRunner.LocalPlayer)
                return;

            Debug.Log("LocalPlayerJoined");

            _playerFactory.Create();
        }
    }
}