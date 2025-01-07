using System.Collections.Generic;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;

namespace SpellProject.Battle.Infrastructure
{
    public class TestPlayerDeckLoader : IPlayerDeckLoader
    {
        public IEnumerable<SpellEntity> LoadDeck()
        {
            var list = new List<SpellEntity>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new SpellEntity("FireBall"));
            }

            return list;
        }
    }
}