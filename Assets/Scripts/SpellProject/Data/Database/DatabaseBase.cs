using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using SpellProject.Utility;
using Takenokohal.Utility;
using UnityEditor;
using UnityEngine;

namespace SpellProject.Data.Database
{
    public abstract class DatabaseBase<T> : SerializedScriptableObject
        where T : IKeyHoldingData
    {
        protected abstract DatabaseURL.SheetName GetSheetName();

        [SerializeField] private List<T> data;

        public IReadOnlyList<T> DataList => data;

        public T FindByKey(string key) => data.First(value => value.Key == key);
        public T FindByIndex(int index) => data[index];
        public int GetIndex(string key) => data.FindIndex(value => value.Key == key);

#if UNITY_EDITOR
        public async UniTask UpdateAsync()
        {
            data.Clear();
            var v = await SpreadSheetLoader.LoadData<T>(DatabaseURL.GetDataURL(GetSheetName()));

            data = v.ToList();
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}