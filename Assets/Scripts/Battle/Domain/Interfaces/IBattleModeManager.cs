using Battle.Network;

namespace Battle.Domain.Interfaces
{
    public interface IBattleModeManager : IInitializeCheckable
    {
        public BattleMode BattleMode { get; }
    }
}