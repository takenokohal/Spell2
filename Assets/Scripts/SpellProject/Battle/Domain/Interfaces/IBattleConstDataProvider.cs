using SpellProject.Battle.Domain.ValueObject;

namespace SpellProject.Battle.Domain.Interfaces
{
    public interface IBattleConstDataProvider
    {
        public BattleConstData GetBattleConstData();
    }
}