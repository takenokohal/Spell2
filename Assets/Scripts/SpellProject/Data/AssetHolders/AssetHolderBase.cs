using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace SpellProject.Data.AssetHolders
{
    public abstract class AssetHolderBase<T> : SerializedScriptableObject where T : Object
    {
        [OdinSerialize] private Dictionary<string, T> _dataList;

        [SerializeField, FolderPath] private string folderPath;


        public IReadOnlyDictionary<string, T> DataList => _dataList;

        public T FindByKey(string key) => _dataList[key];

#if UNITY_EDITOR

        public UniTask UpdateAsync()
        {
            _dataList.Clear();
            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                var asset = AssetDatabase.LoadAssetAtPath<T>(file);
                if (asset == null)
                    continue;
                _dataList.TryAdd(asset.name, asset);
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            return UniTask.CompletedTask;
        }

#endif
    }
}