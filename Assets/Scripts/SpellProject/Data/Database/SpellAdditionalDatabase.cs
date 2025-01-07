using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SpellProject.Battle.Domain.BaseRules.Spell;
using UnityEngine;

namespace SpellProject.Data.Database
{
    [CreateAssetMenu(menuName = "Create SpellAdditionalDatabase", fileName = "SpellAdditionalDatabase", order = 0)]
    public class SpellAdditionalDatabase : SerializedScriptableObject, ISpellAdditionalDatabase
    {
        [OdinSerialize] private List<ISpellAdditionalData> _spellAdditiveDatas;

        T ISpellAdditionalDatabase.GetData<T>()
        {
            var v = _spellAdditiveDatas.First(value => value is T);
            return (T)v;
        }
    }
}