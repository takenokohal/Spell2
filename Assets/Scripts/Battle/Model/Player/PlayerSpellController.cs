using Battle.God.Factory;
using Battle.Model.Spell;
using Cysharp.Threading.Tasks;

namespace Battle.Model.Player
{
    public class PlayerSpellController
    {
        private readonly SpellFactory _spellFactory;

        private readonly PlayerKey _playerKey;

        public PlayerSpellController(SpellFactory spellFactory, PlayerKey playerKey)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
        }

        public void Chant()
        {
            var spell = _spellFactory.Create(_playerKey, "FireBall");

            //処理はSpellに投げっぱなし
            spell.Sequence().Forget();
        }
    }
}