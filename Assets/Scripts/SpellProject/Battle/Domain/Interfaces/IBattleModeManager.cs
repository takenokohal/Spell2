using SpellProject.Battle.Domain.Core;
using Takenokohal.Utility;

namespace SpellProject.Battle.Domain.Interfaces
{
    public interface IBattleModeManager : IInitializeCheckable
    {
        public BattleMode BattleMode { get; }
    }
}