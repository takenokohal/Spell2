using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using SpellProject.Data;
using SpellProject.Utility;
using Takenokohal.Utility;
using UnityEngine;

namespace Test
{
    public class SpreadSheetTest : SerializedMonoBehaviour
    {
        [SerializeField] private SpellData spellData;
        
        [Button]
        private void Test()
        {
            UniTask.Void(async () =>
            {
                var url = DatabaseURL.GetDataURL(DatabaseURL.SheetName.Spell);
                var s = await SpreadSheetLoader.LoadData<SpellData>(url);
                foreach (var dataList in s)
                {
                   // Debug.Log(dataList.spellKey);
                }

                spellData = s[0];
            });
        }
    }
}