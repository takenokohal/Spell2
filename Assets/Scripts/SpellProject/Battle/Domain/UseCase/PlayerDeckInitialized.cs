using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerDeckInitialized
    {
        private readonly IPlayerDeckLoader _playerDeckLoader;
        private readonly PlayerDeck _playerDeck;

        public PlayerDeckInitialized(IPlayerDeckLoader playerDeckLoader, PlayerDeck playerDeck)
        {
            _playerDeckLoader = playerDeckLoader;
            _playerDeck = playerDeck;
        }

        public void Load()
        {
            _playerDeck.Init(_playerDeckLoader.LoadDeck());
        }
    }
}