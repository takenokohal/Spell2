using Battle.God.Factory;
using Battle.Model.Player;
using Cysharp.Threading.Tasks;
using Fusion;
using R3;
using UnityEngine;

namespace Battle.Network
{
    public class NetworkInvertedRpc : NetworkBehaviour, PlayerSpellController.INetworkedSpellChantCall
    {
        private SpellFactory _spellFactory;
        private PlayerKey _playerKey;

        public void Construct(SpellFactory spellFactory, PlayerKey playerKey)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
        }

        public void ChantCall(string spellKey)
        {
            ChantCallRpc(spellKey);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.Proxies, InvokeLocal = false)]
        private void ChantCallRpc(string spellKey)
        {
            Debug.Log(_spellFactory);
            var v = _spellFactory.Create(_playerKey, spellKey);
            v.Sequence().Forget();
        }
    }
}