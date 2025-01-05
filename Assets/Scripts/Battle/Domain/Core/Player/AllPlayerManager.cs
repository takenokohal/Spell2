using System.Collections.Generic;
using System.Linq;

namespace Battle.Domain.Core.Player
{
    public class AllPlayerManager
    {
        private readonly Dictionary<PlayerKey, PlayerFacade> _players = new();
        public IReadOnlyDictionary<PlayerKey, PlayerFacade> Players => _players;

        public void Register(PlayerKey playerKey, PlayerFacade playerMoveController) =>
            _players.Add(playerKey, playerMoveController);

        public PlayerFacade GetPlayer(PlayerKey playerKey) => _players[playerKey];

        public PlayerFacade GetEnemy(PlayerKey playerKey)
        {
            return _players.First(value => value.Key != playerKey).Value;
        }
    }
}