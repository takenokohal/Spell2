using Sirenix.OdinInspector;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Domain.ValueObject;
using UnityEngine;

namespace SpellProject.Battle.Detail.ConstData
{
    
    [CreateAssetMenu(menuName = "Create BattleConstDataProviderProvider", fileName = "BattleConstDataProviderProvider", order = 0)]
    public class BattleConstDataProviderProvider : SerializedScriptableObject , IBattleConstDataProvider
    {
        [SerializeField] private BattleConstData battleConstData;
        
        public BattleConstData GetBattleConstData()
        {
            return battleConstData;
        }
    }
}