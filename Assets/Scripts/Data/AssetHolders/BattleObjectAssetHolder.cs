using System.Collections.Generic;
using Battle.Model.BattleObject;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Data.AssetHolders
{
    [CreateAssetMenu(menuName = "Create BattleObjectAssetHolder", fileName = "BattleObjectAssetHolder", order = 0)]
    public class BattleObjectAssetHolder : SerializedScriptableObject
    {
        [OdinSerialize] private readonly Dictionary<string, BattleObjectBase> _battleObjectBases;

        public BattleObjectBase Find(string bulletKey) => _battleObjectBases[bulletKey];
    }
}