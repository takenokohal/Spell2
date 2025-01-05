using Battle.Domain.Core.Player;
using Battle.Domain.Interfaces.Factory;
using Cysharp.Threading.Tasks;

namespace Battle.Domain.UseCase
{
    public class PlayerSpellUseCase
    {
        private readonly ISpellFactory _spellFactory;

        private readonly PlayerKey _playerKey;

        private readonly INetworkedSpellChantCall _networkedSpellChantCall;

        public PlayerSpellUseCase(ISpellFactory spellFactory, PlayerKey playerKey,
            INetworkedSpellChantCall networkedSpellChantCall)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
            _networkedSpellChantCall = networkedSpellChantCall;
        }

        public void Chant()
        {
            var spellKey = "FireBall";
            var spell = _spellFactory.Create(_playerKey, spellKey);

            //処理はSpellに投げっぱなし
            spell.Sequence().Forget();
        }

        public void NetworkChant()
        {
            var spellKey = "FireBall";
            _networkedSpellChantCall.ChantCall(spellKey);
        }

        public interface INetworkedSpellChantCall
        {
            public void ChantCall(string spellKey);
        }
    }
}