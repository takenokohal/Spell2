using Battle.Domain.BaseRules.Spell;
using Battle.Domain.Core.Player;

namespace Battle.Domain.Interfaces.Factory
{
    public interface ISpellFactory
    {
        public ISpellSequence Create(PlayerKey playerKey, string spellKey);
    }
}