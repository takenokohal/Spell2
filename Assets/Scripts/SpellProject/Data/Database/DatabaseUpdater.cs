using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace SpellProject.Data.Database
{
#if UNITY_EDITOR

    public class DatabaseUpdater : EditorWindow
    {
        [MenuItem("Assets/UpdateAllDatabase")]
        private static void UpdateAllDatabase()
        {
            var spellDatabase = SpellDatabase.LoadOnEditor();
            spellDatabase.UpdateAsync().Forget();
            Debug.Log("UpdateAttack");

            AssetDatabase.SaveAssets();
        }
    }
#endif
}