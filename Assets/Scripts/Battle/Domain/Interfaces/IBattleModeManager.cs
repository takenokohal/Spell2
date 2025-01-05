
using Battle.Domain.Core;

namespace Battle.Domain.Interfaces
{
    public interface IBattleModeManager : IInitializeCheckable
    {
        public BattleMode BattleMode { get; }
    }
}