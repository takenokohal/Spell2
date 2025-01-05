using Battle.Domain.BaseRules.BattleObject;
using Battle.Domain.Core.Player;
using UnityEngine;

namespace Battle.Domain.Interfaces.Factory
{
    public interface IBattleObjectFactory
    {
        public T Create<T>(string objectKey, PlayerKey ownerKey, Vector2 pos, Quaternion rot = default)
            where T : BattleObjectBase;
    }
}