using Cysharp.Threading.Tasks;
using UnityEditor;
using SpellProject.Data.AssetHolders;

namespace SpellProject.Data.Database
{
#if UNITY_EDITOR

    public class DatabaseUpdater : EditorWindow
    {
        [MenuItem("Assets/UpdateAllDatabase")]
        private static void UpdateAllDatabase()
        {
            UpdateAsync().Forget();
        }

        private static async UniTaskVoid UpdateAsync()
        {
            await AssetLoaderOnEditor.LoadDatabaseOnEditor<SpellDatabase>().UpdateAsync();
            await AssetLoaderOnEditor.LoadDatabaseOnEditor<AttackDatabase>().UpdateAsync();
            await AssetLoaderOnEditor.LoadAssetHolderOnEditor<BattleObjectAssetHolder>().UpdateAsync();
            AssetDatabase.SaveAssets();
        }
    }
#endif
}