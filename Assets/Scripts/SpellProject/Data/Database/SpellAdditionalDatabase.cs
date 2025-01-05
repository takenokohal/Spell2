using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace SpellProject.Data.Database
{
    [CreateAssetMenu(menuName = "Create SpellAdditionalDatabase", fileName = "SpellAdditionalDatabase", order = 0)]
    public class SpellAdditionalDatabase : SerializedScriptableObject
    {
        [OdinSerialize] private List<ISpellAdditionalData> _spellAdditiveDatas;

        public T GetData<T>() where T : ISpellAdditionalData
        {
            var v = _spellAdditiveDatas.First(value => value is T);
            return (T)v;
        }
    }
}