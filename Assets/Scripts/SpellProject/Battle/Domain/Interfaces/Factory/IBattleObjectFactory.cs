using SpellProject.Battle.Domain.BaseRules.BattleObject;
using SpellProject.Battle.Domain.Core.Player;
using UnityEngine;

namespace SpellProject.Battle.Domain.Interfaces.Factory
{
    public interface IBattleObjectFactory
    {
        public T Create<T>(string objectKey, PlayerKey ownerKey, Vector2 pos, Quaternion rot = default)
            where T : BattleObjectBase;
    }
}