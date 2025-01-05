namespace SpellProject.Battle.Domain.Core.Player
{
    public class SpellEntity
    {
        public string SpellKey { get; }

        public SpellEntity(string spellKey)
        {
            SpellKey = spellKey;
        }
    }
}