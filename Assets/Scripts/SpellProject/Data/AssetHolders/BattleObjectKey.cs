using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SpellProject.Data.AssetHolders
{
    [Serializable]
    public struct BattleObjectKey
    {
        [SerializeField, ValueDropdown(nameof(GetAttackKeys))]
        private string key;

        public string Key => key;

        public static IEnumerable<string> GetAttackKeys()
        {
            var db = AssetLoaderOnEditor.LoadAssetHolderOnEditor<BattleObjectAssetHolder>();
            return db.DataList.Select(value => value.Key);
        }
    }
}