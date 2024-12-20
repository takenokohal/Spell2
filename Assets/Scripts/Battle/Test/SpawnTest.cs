using Fusion;
using UnityEngine;

namespace Battle.Test
{
    public class SpawnTest : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private GameObject playerPrefab;

        public void PlayerJoined(PlayerRef player)
        {
            if (player != Runner.LocalPlayer)
                return;

            Runner.Spawn(playerPrefab);
        }
    }
}