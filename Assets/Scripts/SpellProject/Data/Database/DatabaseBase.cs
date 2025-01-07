using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SpellProject.Utility;
using Takenokohal.Utility;
using UnityEditor;
using UnityEngine;

namespace SpellProject.Data.Database
{
    public abstract class DatabaseBase<TData> : SerializedScriptableObject
        where TData : IKeyHoldingData
    {
        protected abstract DatabaseURL.SheetName GetSheetName();

        [SerializeField] private List<TData> data;

        public IReadOnlyList<TData> DataList => data;

        public TData FindByKey(string key) => data.First(value => value.Key == key);
        public TData FindByIndex(int index) => data[index];
        public int GetIndex(string key) => data.FindIndex(value => value.Key == key);

#if UNITY_EDITOR
        public async UniTask UpdateAsync()
        {
            data.Clear();
            data = await SpreadSheetLoader.LoadData<TData>(DatabaseURL.GetDataURL(GetSheetName()));

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}