using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerSpellUseCase
    {
        private readonly ISpellChantCall _spellChantCall;
        private readonly PlayerHand _playerHand;
        private readonly PlayerDeck _playerDeck;

        public PlayerSpellUseCase(ISpellChantCall spellChantCall, PlayerHand playerHand, PlayerDeck playerDeck)
        {
            _spellChantCall = spellChantCall;
            _playerHand = playerHand;
            _playerDeck = playerDeck;
        }

        public void Chant(int handIndex)
        {
            var spellEntity = _playerHand.CurrentHand[handIndex];
            
            //オンとオフでここで分岐
            _spellChantCall.Chant(spellEntity.SpellKey);


            //デッキ処理
            _playerDeck.Draw(out var nextSpell);
            _playerHand.Change(handIndex, nextSpell);
        }

        public interface ISpellChantCall
        {
            public void Chant(string spellKey);
        }
    }
}