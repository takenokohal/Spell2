using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Takenokohal.Utility;
using UnityEditor;
using Utility;

namespace Data.Database
{
    public abstract class DatabaseBase<TData, TChild> : SerializedScriptableObject
        where TData : IKeyHoldingData
        where TChild : DatabaseBase<TData, TChild>
    {
        protected abstract DatabaseURL.SheetName GetSheetName();

        [OdinSerialize] private Dictionary<string, TData> _data;
        public IReadOnlyDictionary<string, TData> DataList => _data;

        public TData Find(string key) => _data[key];

#if UNITY_EDITOR
        public async UniTask UpdateAsync()
        {
            _data.Clear();
            var data = await SpreadSheetLoader.LoadData<TData>(DatabaseURL.GetDataURL(GetSheetName()));

            _data = data.ToDictionary(value => value.Key);

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }


        private const string DatabaseFolderPath = "Assets/Databases/";

        public static TChild LoadOnEditor()
        {
            var path = DatabaseFolderPath + typeof(TChild).Name + ".asset";
            var v = AssetDatabase.LoadAssetAtPath<TChild>(path);
            return v;
        }
    }
#endif
}