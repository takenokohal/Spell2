namespace SpellProject.Battle.Domain.BaseRules.Spell
{
    public interface ISpellAdditionalDatabase
    {
        public T GetData<T>() where T : ISpellAdditionalData;
    }
}