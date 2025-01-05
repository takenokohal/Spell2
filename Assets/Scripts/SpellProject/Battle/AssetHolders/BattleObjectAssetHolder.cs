using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SpellProject.Battle.Domain.BaseRules.BattleObject;
using UnityEngine;

namespace SpellProject.Battle.AssetHolders
{
    [CreateAssetMenu(menuName = "Create BattleObjectAssetHolder", fileName = "BattleObjectAssetHolder", order = 0)]
    public class BattleObjectAssetHolder : SerializedScriptableObject
    {
        [OdinSerialize] private readonly Dictionary<string, BattleObjectBase> _battleObjectBases;

        public BattleObjectBase Find(string bulletKey) => _battleObjectBases[bulletKey];
    }
}