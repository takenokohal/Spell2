using Battle.View;
using Fusion;
using UnityEngine;

namespace Battle.Network
{
    public class PlayerSpawnCall : NetworkBehaviour
    {
        public PlayerView PlayerView { get; private set; }

        public override void Spawned()
        {
            PlayerView = GetComponent<PlayerView>();

            var factoryObject = GameObject.FindWithTag("Factory");
            var callBack = factoryObject.GetComponent<IPlayerSpawnCallback>();
            callBack.OnSpawned(this, HasStateAuthority);
        }


        public interface IPlayerSpawnCallback
        {
            public void OnSpawned(PlayerSpawnCall playerSpawnCall, bool hasAuthority);
        }
    }
}