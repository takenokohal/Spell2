using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;

namespace SpellProject.Battle.Domain.UseCase
{
    public class OfflinePlayerSpellChant : PlayerSpellUseCase.ISpellChantCall
    {
        private readonly ISpellFactory _spellFactory;

        private readonly PlayerKey _playerKey;

        public OfflinePlayerSpellChant(ISpellFactory spellFactory, PlayerKey playerKey)
        {
            _spellFactory = spellFactory;
            _playerKey = playerKey;
        }
        public void Chant(string spellKey)
        {
            var spell = _spellFactory.Create(_playerKey, spellKey);

            //処理はSpellに投げっぱなし
            spell.Sequence().Forget();
        }
    }
}