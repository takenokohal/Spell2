using System;
using Cysharp.Threading.Tasks;
using Fusion;
using SpellProject.Battle.Domain.Core;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Network;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God
{
    public class BattleEntryPoint : SimulationBehaviour, IPlayerJoined
    {
        [Inject] private readonly NetworkRunner _networkRunner;

        [Inject] private readonly IBattleModeManager _battleModeManager;
        [SerializeField] private PlayerSpawnCall playerSpawnCallPrefab;

        private void Start()
        {
            InitAsync().Forget();
        }

        private async UniTaskVoid InitAsync()
        {
            await _battleModeManager.WaitUntilInitialize(destroyCancellationToken);

            switch (_battleModeManager.BattleMode)
            {
                case BattleMode.Online:
                    OnlineMode().Forget();
                    break;
                case BattleMode.OfflineVersus:
                    for (int i = 0; i < 2; i++)
                    {
                        var x = i == 0 ? 1 : -1;
                        Instantiate(playerSpawnCallPrefab, new Vector3(5 * x, 0), Quaternion.identity);
                    }
                    break;
                case BattleMode.OfflineSingle:
                    break;
                case BattleMode.Training:
                    for (int i = 0; i < 2; i++)
                    {
                        var x = i == 0 ? -1 : 1;
                        Instantiate(playerSpawnCallPrefab, new Vector3(5 * x, 0), Quaternion.identity);
                    }

                    break;
                case BattleMode.Tutorial:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private async UniTaskVoid OnlineMode()
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
            if (player != _networkRunner.LocalPlayer)
                return;

            Debug.Log("LocalPlayerJoined");

            _networkRunner.Spawn(playerSpawnCallPrefab);
        }
    }
}