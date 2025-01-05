using SpellProject.Battle.Domain.BaseRules.Spell;
using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Domain.Interfaces.Factory
{
    public interface ISpellFactory
    {
        public ISpellSequence Create(PlayerKey playerKey, string spellKey);
    }
}