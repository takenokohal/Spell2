using Cysharp.Threading.Tasks;
using Fusion;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;
using SpellProject.Battle.Domain.UseCase;
using SpellProject.Data.Database;

namespace SpellProject.Battle.Network
{
    public class NetworkPlayerChant : NetworkBehaviour, PlayerSpellUseCase.ISpellChantCall
    {
        private ISpellFactory _spellFactory;
        private PlayerKey _playerKey;
        private SpellDatabase _spellDatabase;

        public void Construct(ISpellFactory spellFactory, PlayerKey playerKey, SpellDatabase spellDatabase)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
            _spellDatabase = spellDatabase;
        }

        public void Chant(string spellKey)
        {
            var index = _spellDatabase.GetIndex(spellKey);
            ChantCallRpc((byte)index);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.Proxies, InvokeLocal = false)]
        private void ChantCallRpc(byte spellIndex)
        {
            var key = _spellDatabase.FindByIndex(spellIndex).spellKey;
            var v = _spellFactory.Create(_playerKey, key);
            v.Sequence().Forget();
        }
    }
}