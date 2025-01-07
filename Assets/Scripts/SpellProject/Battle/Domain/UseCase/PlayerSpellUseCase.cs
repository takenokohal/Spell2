using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerSpellUseCase
    {
        private readonly ISpellFactory _spellFactory;

        private readonly PlayerKey _playerKey;

        private readonly INetworkedSpellChantCall _networkedSpellChantCall;

        private readonly PlayerDeck _playerDeck;
        private readonly PlayerHand _playerHand;

        public PlayerSpellUseCase(ISpellFactory spellFactory, PlayerKey playerKey, INetworkedSpellChantCall networkedSpellChantCall, PlayerDeck playerDeck, PlayerHand playerHand)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
            _networkedSpellChantCall = networkedSpellChantCall;
            _playerDeck = playerDeck;
            _playerHand = playerHand;
        }

        public void Chant(int handIndex)
        {
            var spellEntity = _playerHand.CurrentHand[handIndex];
            var spell = _spellFactory.Create(_playerKey, spellEntity.SpellKey);

            //処理はSpellに投げっぱなし
            spell.Sequence().Forget();
            
            //デッキ処理
            _playerDeck.Draw(out var nextSpell);
            _playerHand.Change(handIndex, nextSpell);
        }

        public void NetworkChant(int handIndex)
        {
            var spellEntity = _playerHand.CurrentHand[handIndex];
            _networkedSpellChantCall.ChantCall(spellEntity.SpellKey);
        }

        public interface INetworkedSpellChantCall
        {
            public void ChantCall(string spellKey);
        }
    }
}