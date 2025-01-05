using Cysharp.Threading.Tasks;
using Fusion;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;
using SpellProject.Battle.Domain.UseCase;
using UnityEngine;

namespace SpellProject.Battle.Network
{
    public class NetworkInvertedRpc : NetworkBehaviour, PlayerSpellUseCase.INetworkedSpellChantCall
    {
        private ISpellFactory _spellFactory;
        private PlayerKey _playerKey;

        public void Construct(ISpellFactory spellFactory, PlayerKey playerKey)
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