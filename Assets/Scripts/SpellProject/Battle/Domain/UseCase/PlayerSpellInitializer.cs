using System.Collections.Generic;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerSpellInitializer
    {
        private readonly IPlayerDeckLoader _playerDeckLoader;
        private readonly PlayerDeck _playerDeck;
        private readonly PlayerHand _playerHand;

        public PlayerSpellInitializer(IPlayerDeckLoader playerDeckLoader, PlayerDeck playerDeck, PlayerHand playerHand)
        {
            _playerDeckLoader = playerDeckLoader;
            _playerDeck = playerDeck;
            _playerHand = playerHand;
        }

        public void InitializeAll()
        {
            _playerDeck.Init(_playerDeckLoader.LoadDeck());
            var handMax = 4;
            var list = new List<SpellEntity>();
            for (int i = 0; i < handMax; i++)
            {
                _playerDeck.Draw(out var spellEntity);
                list.Add(spellEntity);
            }
            _playerHand.Initialize(list);
        }
    }
}