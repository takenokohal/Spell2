using UnityEditor;
using UnityEngine;

namespace SpellProject.Data
{
    public static class AssetLoaderOnEditor
    {
        private const string DatabaseFolderPath = "Assets/Databases/";

        public static T LoadDatabaseOnEditor<T>() where T : ScriptableObject
        {
            var path = DatabaseFolderPath + typeof(T).Name + ".asset";
            var v = AssetDatabase.LoadAssetAtPath<T>(path);
            return v;
        }

        private const string AssetHolderFolderPath = DatabaseFolderPath + "AssetHolders/";

        public static T LoadAssetHolderOnEditor<T>() where T : ScriptableObject
        {
            var path = AssetHolderFolderPath + typeof(T).Name + ".asset";
            var v = AssetDatabase.LoadAssetAtPath<T>(path);
            return v;
        }
    }
}