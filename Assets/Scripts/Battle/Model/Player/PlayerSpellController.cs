using Battle.God.Factory;
using Cysharp.Threading.Tasks;
using R3;

namespace Battle.Model.Player
{
    public class PlayerSpellController
    {
        private readonly SpellFactory _spellFactory;

        private readonly PlayerKey _playerKey;

        private readonly INetworkedSpellChantCall _networkedSpellChantCall;

        public PlayerSpellController(SpellFactory spellFactory, PlayerKey playerKey,
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