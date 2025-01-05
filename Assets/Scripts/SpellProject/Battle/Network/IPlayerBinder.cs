using UnityEngine;

namespace SpellProject.Battle.Network
{
    public interface IPlayerBinder
    {
        public void Bind(PlayerSpawnCall playerSpawnCall, bool hasAuthority);

        public static IPlayerBinder Find()
        {
            var binderObject = GameObject.FindWithTag("Binder");
            return binderObject.GetComponent<IPlayerBinder>();
        }
    }
}