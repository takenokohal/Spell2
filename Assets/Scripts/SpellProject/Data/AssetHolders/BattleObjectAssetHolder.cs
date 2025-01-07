using SpellProject.Battle.Domain.BaseRules.BattleObject;
using UnityEngine;

namespace SpellProject.Data.AssetHolders
{
    [CreateAssetMenu(menuName = "Create BattleObjectAssetHolder", fileName = "BattleObjectAssetHolder", order = 0)]
    public class BattleObjectAssetHolder : AssetHolderBase<BattleObjectBase>
    {
    }
}