using System.Collections.Generic;
using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Domain.Interfaces.Player
{
    public interface IPlayerDeckLoader
    {
        public IEnumerable<SpellEntity> LoadDeck();
    }
}